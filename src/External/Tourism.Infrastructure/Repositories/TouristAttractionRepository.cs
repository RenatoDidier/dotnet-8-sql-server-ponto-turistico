using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tourism.Application.Exceptions;
using Tourism.Application.Interfaces.Tourism;
using Tourism.Domain.Entities;
using Tourism.Infrastructure.Contexts;

namespace Tourism.Infrastructure.Repositories;

public sealed class TouristAttractionRepository : ITouristAttractionRepository
{
    private readonly TourismDbContext _context;
    private readonly ILogger<TouristAttractionRepository> _logger;
    public TouristAttractionRepository(TourismDbContext context, ILogger<TouristAttractionRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Guid> CreateAsync(TouristAttractionEntity entity, CancellationToken ct)
    {
        _logger.LogInformation("Executando SP PRC_Tourist_Attraction_Create. Id={Id}", entity.Id);

        try
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC PRC_Tourist_Attraction_Create @Id, @Title, @City, @UF, @Reference, @Description",
                new[]
                {
                    new SqlParameter("@Id", entity.Id),
                    new SqlParameter("@Title", entity.Title),
                    new SqlParameter("@City", entity.City),
                    new SqlParameter("@UF", entity.UF),
                    new SqlParameter("@Reference", entity.Reference),
                    new SqlParameter("@Description", entity.Description),
                },
                ct
            );

            return entity.Id;

        } catch (SqlException ex)
        {
            throw new PersistenceException(
                "Ocorreu um erro ao cadastrar o ponto turístico.",
                ex);
        }
    }

    public async Task<Guid> UpdateAsync(UpdateTouristAttractionDto dto, CancellationToken ct)
    {
        _logger.LogInformation("Executando SP PRC_Tourist_Attraction_Update. Id={Id}", dto.Id);

        try
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC PRC_Tourist_Attraction_Update @Id, @Title, @City, @UF, @Reference, @Description",
                new[]
                {
                    new SqlParameter("@Id", dto.Id),
                    new SqlParameter("@Title", dto.Title),
                    new SqlParameter("@City", dto.City),
                    new SqlParameter("@UF", dto.UF),
                    new SqlParameter("@Reference", dto.Reference),
                    new SqlParameter("@Description", dto.Description),
                },
                ct
            );

            return dto.Id;

        }
        catch (SqlException ex)
        {
            throw new PersistenceException(
                "Ocorreu um erro ao atualizar o ponto turístico.",
                ex);
        }
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
    {
        _logger.LogInformation("Executando SP PRC_Tourist_Attraction_Delete. Id={Id}", id);

        try
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC PRC_Tourist_Attraction_Delete @Id",
                new[]
                {
                      new SqlParameter("@Id", id),
                },
                ct
            );

            return true;
        }
        catch (SqlException ex)
        {
            throw new PersistenceException(
                "Ocorreu um erro ao excluir o ponto turístico.",
                ex);
        }
    }

}
