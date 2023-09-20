using Application.Common.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Exceptions;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _httpExceptionHandler = new HttpExceptionHandler();

    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {

            await HandlerExceptionAsync(context.Response, exception);
        }

    }

    private Task HandlerExceptionAsync(HttpResponse httpResponse, Exception exception)
    {
        httpResponse.ContentType = "application/json";
        _httpExceptionHandler.Response = httpResponse;
        return _httpExceptionHandler.HandlerExceptionAsync(exception);
    }
}
