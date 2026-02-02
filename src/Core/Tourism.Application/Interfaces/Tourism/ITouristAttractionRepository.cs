using Tourism.Application.Models.Dto;
using Tourism.Domain.Entities;

namespace Tourism.Application.Interfaces.Tourism;

public interface ITouristAttractionRepository
{
    Task<IReadOnlyCollection<TouristAttractionListItemDto>> ListPagedAsync(PagedTouristAttractionDto entity, CancellationToken ct);
    Task<Guid> CreateAsync(TouristAttractionEntity entity, CancellationToken ct);
    Task<Guid> UpdateAsync(UpdateTouristAttractionDto dto, CancellationToken ct);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct);
}
