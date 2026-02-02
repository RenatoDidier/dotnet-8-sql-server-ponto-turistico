using Tourism.Application.Models.Dto;

namespace Tourism.Application.Contracts.Tourism;

public interface ITouristAttractionService
{
    Task<Guid> CreateAsync(CreateTouristAttractionDto dto, CancellationToken ct);
    Task<Guid> UpdateAsync(UpdateTouristAttractionDto dto, CancellationToken ct);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct);
}
