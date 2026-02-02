using Tourism.Domain.Interfaces;

namespace Tourism.Domain.Test.Fakes;

public sealed class FakeProvider : IProvider
{
    public Guid FixedGuid { get; } =
    Guid.Parse("11111111-1111-1111-1111-111111111111");

    public DateTime FixedDate { get; } =
        new DateTime(2025, 01, 01, 12, 00, 00, DateTimeKind.Utc);

    public Guid NewGuid() => FixedGuid;

    public DateTime DateTimeUtcNow() => FixedDate;
}
