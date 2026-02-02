using Tourism.Domain.Entities;

namespace Tourism.Application.Models.Dto;

public sealed class TouristAttractionListItemDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string City { get; init; } = default!;
    public string UF { get; init; } = default!;
    public string Reference { get; init; } = default!;
    public DateTime CreatedAt { get; init; }

    public int TotalItems { get; init; }
}
