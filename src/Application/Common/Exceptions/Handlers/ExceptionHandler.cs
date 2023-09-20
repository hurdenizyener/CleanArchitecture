using Application.Common.Exceptions.Types;

namespace Application.Common.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandlerExceptionAsync(Exception exception) =>
        exception switch
        {
            BusinessException businessException => HandlerException(businessException),
            _ => HandlerException(exception)//Hiçbiri İse
        };

    protected abstract Task HandlerException(BusinessException businessException);
    protected abstract Task HandlerException(Exception exception);

}
