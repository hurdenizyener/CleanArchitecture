using Application.Common.Exceptions.Handlers;
using Application.Common.Logging;
using Application.Common.Logging.Serilog;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Application.Common.Exceptions;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly LoggerServiceBase _loggerService;

    public ExceptionMiddleware(RequestDelegate next, IHttpContextAccessor contextAccessor, LoggerServiceBase loggerService)
    {
        _next = next;
        _httpExceptionHandler = new HttpExceptionHandler();
        _contextAccessor = contextAccessor;
        _loggerService = loggerService;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await LogException(context, exception);
            await HandlerExceptionAsync(context.Response, exception);
        }

    }

    private Task LogException(HttpContext context, Exception exception)
    {
        List<LogParameter> logParameters = new()
        {
            new LogParameter
            {
                Type=context.GetType().Name,
                Value=exception.ToString()
            }
        };

        LogDetailWithException logDetailWithException = new()
        {
            ExceptionMessage=exception.Message,
            MethodName = _next.Method.Name,
            Parameters = logParameters,
            User = _contextAccessor.HttpContext?.User.Identity?.Name ?? "?"
        };

        _loggerService.Error(JsonSerializer.Serialize(logDetailWithException));

        return Task.CompletedTask;
    }

    private Task HandlerExceptionAsync(HttpResponse httpResponse, Exception exception)
    {
        httpResponse.ContentType = "application/json";
        _httpExceptionHandler.Response = httpResponse;
        return _httpExceptionHandler.HandlerExceptionAsync(exception);
    }
}
