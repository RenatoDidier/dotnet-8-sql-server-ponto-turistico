using Tourism.Domain.Common;

namespace Tourism.Domain.Entities;

public class TouristAttractionEntity : BaseEntity
{
    public const int TITLE_MAX_LENGTH = 100;
    public const int CITY_MAX_LENGTH = 100;
    public const int UF_MAX_LENGTH = 2;
    public const int REFERENCE_MAX_LENGTH = 100;
    public const int DESCRIPTION_MAX_LENGTH = 100;

    public string City { get; private set; } = default!;
    public string UF { get; private set; } = default!;
    public string Reference { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    
    protected TouristAttractionEntity() { }

    public TouristAttractionEntity(
        Guid id,
        string title,
        string city,
        string uf,
        string reference,
        string description)
        : base(id, title)
    {
        City = city;
        UF = uf;
        Reference = reference;
        Description = description;
    }

    public void UpdateDetails(
        string title,
        string city,
        string uf,
        string description,
        string reference)
    {
        UpdateTitle(title);

        City = city;
        UF = uf;
        Description = description;
        Reference = reference;
    }
}
