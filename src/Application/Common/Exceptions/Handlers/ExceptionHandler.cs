using Application.Common.Exceptions.Types;

namespace Application.Common.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandlerExceptionAsync(Exception exception) =>
        exception switch
        {
            BusinessException businessException => HandlerException(businessException),
            ValidationException validationException => HandlerException(validationException),
            _ => HandlerException(exception)//Hiçbiri İse
        };

    protected abstract Task HandlerException(BusinessException businessException);
    protected abstract Task HandlerException(ValidationException validationException);
    protected abstract Task HandlerException(Exception exception);

}
