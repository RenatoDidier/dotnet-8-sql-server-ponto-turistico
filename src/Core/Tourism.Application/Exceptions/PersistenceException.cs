namespace Tourism.Application.Exceptions;

public sealed class PersistenceException : Exception
{
    public PersistenceException(string message, Exception innerException)
    : base(message, innerException)
    {
    }
}
