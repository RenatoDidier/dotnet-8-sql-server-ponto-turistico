using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Tourism.Application.Interfaces.Tourism;
using Tourism.Application.Models.Dto;
using Tourism.Application.Services.Tourism;
using Tourism.Domain.Entities;
using Tourism.Domain.Test.Fakes;

namespace Tourism.Application.Test.Services;

public class TouristAttractionServiceTests
{
    [Fact]
    public async Task CreateAsync_Should_Create_Entity_And_Return_Id()
    {
        // Arrange
        var provider = new FakeProvider();

        var dto = new CreateTouristAttractionDto(
            "Cristo Redentor",
            "Rio de Janeiro",
            "RJ",
            "Parque Nacional",
            "Ponto turístico"
        );

        var repositoryMock = new Mock<ITouristAttractionRepository>();
        repositoryMock
            .Setup(r => r.CreateAsync(It.IsAny<TouristAttractionEntity>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(provider.FixedGuid);

        var logger = NullLogger<TouristAttractionService>.Instance;

        var service = new TouristAttractionService(
            repositoryMock.Object,
            logger,
            provider
        );

        // Act
        var result = await service.CreateAsync(dto, CancellationToken.None);

        // Assert
        Assert.Equal(provider.FixedGuid, result);

        repositoryMock.Verify(r =>
            r.CreateAsync(
                It.Is<TouristAttractionEntity>(e =>
                    e.Id == provider.FixedGuid &&
                    e.Title == dto.Title &&
                    e.City == dto.City &&
                    e.UF == dto.UF &&
                    e.Reference == dto.Reference &&
                    e.Description == dto.Description
                ),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateAsync_Should_Propagate_Exception_From_Repository()
    {
        // Arrange
        var provider = new FakeProvider();

        var dto = new CreateTouristAttractionDto(
            "Teste",
            "Cidade",
            "SP",
            "Ref",
            "Desc"
        );

        var repositoryMock = new Mock<ITouristAttractionRepository>();
        repositoryMock
            .Setup(r => r.CreateAsync(It.IsAny<TouristAttractionEntity>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("Erro no banco"));

        var logger = NullLogger<TouristAttractionService>.Instance;

        var service = new TouristAttractionService(
            repositoryMock.Object,
            logger,
            provider
        );

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.CreateAsync(dto, CancellationToken.None));

        repositoryMock.Verify(r =>
            r.CreateAsync(It.IsAny<TouristAttractionEntity>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
