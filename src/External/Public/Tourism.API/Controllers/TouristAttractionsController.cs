using Microsoft.AspNetCore.Mvc;
using Tourism.API.Contracts.Requests.Tourism;
using Tourism.Application.Contracts.Tourism;
using Tourism.Application.Models.Dto;

namespace Tourism.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TouristAttractionsController : ControllerBase
{
    private readonly ITouristAttractionService _service;
    private readonly ILogger<TouristAttractionsController> _logger;

    public TouristAttractionsController(ILogger<TouristAttractionsController> logger, ITouristAttractionService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost(Name = "Create")]
    public async Task<IActionResult> CreateTouristAttraction(CreateTouristAttractionRequest request, CancellationToken ct)
    {
        _logger.LogInformation("Criando o ponto turístico: Title={Title}", request.Title);

        var dto = new CreateTouristAttractionDto(
            request.Title,
            request.City,
            request.UF,
            request.Reference,
            request.Description
        );

        var id = await _service.CreateAsync(dto, ct);

        return StatusCode(StatusCodes.Status201Created, new { id });
    }

    [HttpPut(Name = "Update")]
    public async Task<IActionResult> UpdateTouristAttraction(UpdateTouristAttractionRequest request, CancellationToken ct)
    {
        _logger.LogInformation("Atualizando o ponto turístico: Id={Id} Title={Title}",request.Id, request.Title);

        var dto = new UpdateTouristAttractionDto(
            request.Id,
            request.Title,
            request.City,
            request.UF,
            request.Reference,
            request.Description
        );

        var id = await _service.UpdateAsync(dto, ct);

        return StatusCode(StatusCodes.Status201Created, new { id });
    }

    [HttpDelete(Name = "Delete/{id:guid}")]
    public async Task<IActionResult> DeleteTouristAttraction(Guid id, CancellationToken ct)
    {
        _logger.LogInformation("Excluindo ponto turístico: Id={Id}", id);

        var deleted = await _service.DeleteAsync(id, ct);

        if (!deleted)
            return NotFound();
        
        return NoContent();

    }

}
