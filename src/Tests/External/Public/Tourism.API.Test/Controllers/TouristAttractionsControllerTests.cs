using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Tourism.API.Controllers;
using Tourism.API.Contracts.Requests.Tourism;
using Tourism.Application.Contracts.Tourism;
using Tourism.Application.Models.Dto;
using Xunit;

namespace Tourism.API.Tests.Controllers;

public class TouristAttractionsControllerTests
{
    [Fact]
    public async Task CreateTouristAttraction_Should_Return_201_And_Id()
    {
        // Arrange
        var expectedId = Guid.NewGuid();

        var request = new CreateTouristAttractionRequest("Cristo Redentor", "Rio de Janeiro", "RJ", "Parque Nacional", "Ponto turístico");

        var serviceMock = new Mock<ITouristAttractionService>();
        serviceMock
            .Setup(s => s.CreateAsync(
                It.IsAny<CreateTouristAttractionDto>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedId);

        var logger = NullLogger<TouristAttractionsController>.Instance;

        var controller = new TouristAttractionsController(
            logger,
            serviceMock.Object);

        // Act
        var result = await controller.CreateTouristAttraction(
            request,
            CancellationToken.None);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status201Created, objectResult.StatusCode);

        var response = objectResult.Value;
        Assert.NotNull(response);

        var idProperty = response.GetType().GetProperty("id");
        Assert.NotNull(idProperty);
        Assert.Equal(expectedId, idProperty.GetValue(response));

        serviceMock.Verify(s =>
            s.CreateAsync(
                It.Is<CreateTouristAttractionDto>(dto =>
                    dto.Title == request.Title &&
                    dto.City == request.City &&
                    dto.UF == request.UF &&
                    dto.Reference == request.Reference &&
                    dto.Description == request.Description
                ),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateTouristAttraction_Should_Propagate_Exception()
    {
        // Arrange
        var request = new CreateTouristAttractionRequest("Erro", "Cidade", "SP", "Referência", "Descrição");

        var serviceMock = new Mock<ITouristAttractionService>();
        serviceMock
            .Setup(s => s.CreateAsync(
                It.IsAny<CreateTouristAttractionDto>(),
                It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("Erro interno"));

        var logger = NullLogger<TouristAttractionsController>.Instance;

        var controller = new TouristAttractionsController(
            logger,
            serviceMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            controller.CreateTouristAttraction(
                request,
                CancellationToken.None));

        serviceMock.Verify(s =>
            s.CreateAsync(
                It.IsAny<CreateTouristAttractionDto>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
}