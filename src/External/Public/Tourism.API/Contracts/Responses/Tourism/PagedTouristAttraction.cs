using Tourism.Application.Models.Dto;

namespace Tourism.API.Contracts.Responses.Tourism;

public class PagedTouristAttraction
{
    public sealed class Response
    {
        public int TotalItems { get; private set; }
        public List<TouristAttractionResponse> Items { get; } = new();

        public void AddTotalItems(int totalItems)
        {
            TotalItems = totalItems;
        }
        public void AddItems(IReadOnlyCollection<TouristAttractionListItemDto> items)
        {
            Items.Clear();
            Items.AddRange(
                items.Select(item => new TouristAttractionResponse
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    City = item.City,
                    UF = item.UF,
                    Reference = item.Reference
                })
            );
        }
    }
}

public sealed class TouristAttractionResponse
{
    public Guid Id { get; init; } = default!;
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string City { get; init; } = default!;
    public string UF { get; init; } = default!;
    public string Reference { get; init; } = default!;
}
