namespace Application.Common.Exceptions.Types;

public sealed class BusinessException : Exception
{
    public BusinessException()
    {
    }

    public BusinessException(string? message) : base(message)
    {
    }

}
