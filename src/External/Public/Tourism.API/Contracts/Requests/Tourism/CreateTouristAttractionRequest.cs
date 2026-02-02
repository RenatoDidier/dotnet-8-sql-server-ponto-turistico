namespace Tourism.API.Contracts.Requests.Tourism;

public record CreateTouristAttractionRequest(
        string Title, 
        string City,
        string UF,
        string Reference,
        string Description
    );
