namespace Tourism.Domain.Interfaces;

public interface IProvider
{
    public Guid NewGuid();
    public DateTime DateTimeUtcNow();
}
