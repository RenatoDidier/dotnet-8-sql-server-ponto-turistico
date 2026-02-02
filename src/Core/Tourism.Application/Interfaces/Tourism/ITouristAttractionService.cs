using Tourism.Application.Models.Dto;

namespace Tourism.Application.Contracts.Tourism;

public interface ITouristAttractionService
{
    Task<Guid> CreateAsync(CreateTouristAttractionDto dto, CancellationToken ct);
}
