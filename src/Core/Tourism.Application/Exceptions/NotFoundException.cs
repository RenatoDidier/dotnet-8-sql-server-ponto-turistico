namespace Tourism.Application.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(string message, Exception innerException)
    : base(message, innerException)
    {
    }
}
