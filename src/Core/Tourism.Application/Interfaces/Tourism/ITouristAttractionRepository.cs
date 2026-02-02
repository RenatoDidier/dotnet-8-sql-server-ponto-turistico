using Tourism.Domain.Entities;

namespace Tourism.Application.Interfaces.Tourism;

public interface ITouristAttractionRepository
{
    Task<Guid> CreateAsync(TouristAttractionEntity entity, CancellationToken ct);
}
