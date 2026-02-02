namespace Tourism.API.Contracts.Requests.Tourism;
public record UpdateTouristAttractionRequest(
        Guid Id,
        string Title,
        string City,
        string UF,
        string Reference,
        string Description
    );