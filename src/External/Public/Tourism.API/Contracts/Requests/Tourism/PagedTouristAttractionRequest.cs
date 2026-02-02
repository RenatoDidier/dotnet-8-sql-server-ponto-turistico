namespace Tourism.API.Contracts.Requests.Tourism;

public sealed class PagedTouristAttractionRequest
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? Search { get; init; }
}
