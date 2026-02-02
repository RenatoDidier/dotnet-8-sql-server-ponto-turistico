using Tourism.Application.Contracts.Tourism;
using Tourism.Application.Interfaces.Tourism;
using Tourism.Application.Models.Dto;
using Tourism.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Tourism.Application.Services.Tourism;

public class TouristAttractionService : ITouristAttractionService
{
    private readonly ITouristAttractionRepository _repository;
    private readonly ILogger<TouristAttractionService> _logger;
    public TouristAttractionService(ITouristAttractionRepository repository, ILogger<TouristAttractionService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<Guid> CreateAsync(CreateTouristAttractionDto dto, CancellationToken ct)
    {
        var entity = new TouristAttractionEntity(
            Guid.NewGuid(),
            dto.Title,
            dto.City,
            dto.UF,
            dto.Reference,
            dto.Description
        );

        _logger.LogInformation("Criando o ponto turístico: Id={Id}", entity.Id);

        return await _repository.CreateAsync(entity, ct);
    }
}
