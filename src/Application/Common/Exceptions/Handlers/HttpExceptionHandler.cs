using Application.Common.Exceptions.Extensions;
using Application.Common.Exceptions.HttpProblemDetails;
using Application.Common.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Exceptions.Handlers;

public sealed class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;
    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }

    protected override Task HandlerException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    //Internal Server Error 
    //Öngörmediğimiz Hatalar İçin
    protected override Task HandlerException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new InternalServerErrorProblemDetails(exception.Message).AsJson();
        return Response.WriteAsync(details);
    }
}
