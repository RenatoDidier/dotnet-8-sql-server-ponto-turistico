namespace Tourism.Application.Models.Dto;

public record CreateTouristAttractionDto(
        string Title,
        string City,
        string UF,
        string Reference,
        string Description
    );
