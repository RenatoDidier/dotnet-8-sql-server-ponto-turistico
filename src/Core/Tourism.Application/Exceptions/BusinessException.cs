namespace Tourism.Application.Exceptions;

public sealed class BusinessException : Exception
{
    public BusinessException(string message, Exception innerException)
    : base(message, innerException)
    {
    }
}
