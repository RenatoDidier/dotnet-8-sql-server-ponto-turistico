using Tourism.Domain.Interfaces;

namespace Tourism.Domain.Common;

public class Provider : IProvider
{
    public DateTime DateTimeUtcNow()
    {
        return DateTime.UtcNow;
    }

    public Guid NewGuid()
    {
        return Guid.NewGuid();
    }
}
