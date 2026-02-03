using Tourism.Application.Models.Dto;

namespace Tourism.API.Contracts.Responses.Tourism;

public sealed class AdminTouristAttraction
{
    public sealed class Response
    {
        public List<AdminResponse> Items { get; } = new();

        public void AddItems(IReadOnlyCollection<TouristAttractionListItemDto> items)
        {
            Items.Clear();
            Items.AddRange(
                items.Select(item => new AdminResponse
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    City = item.City,
                    UF = item.UF,
                    Reference = item.Reference,
                    CreatedAt = item.CreatedAt.ToString("dd/MM/yyyy")
                })
            );
        }
    }

}

public sealed class AdminResponse
{
    public Guid Id { get; init; } = default!;
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string City { get; init; } = default!;
    public string UF { get; init; } = default!;
    public string Reference { get; init; } = default!;
    public string CreatedAt { get; init; } = default!;
}
 