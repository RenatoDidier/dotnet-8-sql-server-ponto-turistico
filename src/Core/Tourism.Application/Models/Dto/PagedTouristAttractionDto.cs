namespace Tourism.Application.Models.Dto;

public sealed class PagedTouristAttractionDto
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public string? Search {  get; init; }
}
