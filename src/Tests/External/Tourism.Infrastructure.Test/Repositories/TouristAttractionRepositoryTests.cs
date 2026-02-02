using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Tourism.Application.Exceptions;
using Tourism.Domain.Entities;
using Tourism.Domain.Test.Fakes;
using Tourism.Infrastructure.Contexts;
using Tourism.Infrastructure.Repositories;

public class TouristAttractionRepositoryTests : IClassFixture<SqlServerFixture>
{
    private readonly SqlServerFixture _fixture;

    public TouristAttractionRepositoryTests(SqlServerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateAsync_Should_Insert_Record_And_Return_Id()
    {
        // Arrange
        var provider = new FakeProvider();

        var options = new DbContextOptionsBuilder<TourismDbContext>()
            .UseSqlServer(_fixture.ConnectionString)
            .Options;

        var context = new TourismDbContext(options);

        var repository = new TouristAttractionRepository(
            context,
            NullLogger<TouristAttractionRepository>.Instance);

        var entity = new TouristAttractionEntity(
            "Cristo Redentor",
            "Rio de Janeiro",
            "RJ",
            "Parque Nacional",
            "Ponto turístico",
            provider);

        // Act
        var id = await repository.CreateAsync(entity, CancellationToken.None);

        // Assert
        Assert.Equal(entity.Id, id);

        var exists = await context.Set<TouristAttractionEntity>()
            .AnyAsync(x => x.Id == id);

        Assert.True(exists);
    }

    [Fact]
    public async Task CreateAsync_Should_Throw_PersistenceException_When_Sql_Fails()
    {
        // Arrange
        var provider = new FakeProvider();

        var options = new DbContextOptionsBuilder<TourismDbContext>()
            .UseSqlServer("Server=invalid;Database=invalid;User Id=sa;Password=wrong;")
            .Options;

        var context = new TourismDbContext(options);

        var repository = new TouristAttractionRepository(
            context,
            NullLogger<TouristAttractionRepository>.Instance);

        var entity = new TouristAttractionEntity(
            "Teste",
            "Cidade",
            "SP",
            "Ref",
            "Desc",
            provider);

        // Act & Assert
        await Assert.ThrowsAsync<PersistenceException>(() =>
            repository.CreateAsync(entity, CancellationToken.None));
    }
}