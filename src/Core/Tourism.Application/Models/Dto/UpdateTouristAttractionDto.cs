public record UpdateTouristAttractionDto(
        Guid Id,
        string Title,
        string City,
        string UF,
        string Reference,
        string Description
    );