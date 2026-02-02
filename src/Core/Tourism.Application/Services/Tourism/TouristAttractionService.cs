using Tourism.Application.Contracts.Tourism;
using Tourism.Application.Interfaces.Tourism;
using Tourism.Application.Models.Dto;
using Tourism.Domain.Entities;
using Microsoft.Extensions.Logging;
using Tourism.Domain.Interfaces;

namespace Tourism.Application.Services.Tourism;

public class TouristAttractionService : ITouristAttractionService
{
    private readonly ITouristAttractionRepository _repository;
    private readonly ILogger<TouristAttractionService> _logger;
    private readonly IProvider _provider;
    public TouristAttractionService(ITouristAttractionRepository repository, ILogger<TouristAttractionService> logger, IProvider provider)
    {
        _repository = repository;
        _logger = logger;
        _provider = provider;
    }
    public async Task<Guid> CreateAsync(CreateTouristAttractionDto dto, CancellationToken ct)
    {
        var entity = new TouristAttractionEntity(
            dto.Title,
            dto.City,
            dto.UF,
            dto.Reference,
            dto.Description,
           _provider
        );

        _logger.LogInformation("Criando o ponto turístico: Id={Id}", entity.Id);

        return await _repository.CreateAsync(entity, ct);
    }
}
