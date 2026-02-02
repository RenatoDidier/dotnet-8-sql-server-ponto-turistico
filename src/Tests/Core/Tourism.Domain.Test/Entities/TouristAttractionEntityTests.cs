using Tourism.Domain.Entities;
using Tourism.Domain.Test.Fakes;
using Xunit;

namespace Tourism.Domain.Tests.Entities;

public class TouristAttractionEntityTests
{
    [Fact]
    public void Constructor_Should_Create_Entity_With_All_Properties()
    {
        // Arrange
        var provider = new FakeProvider();

        var title = "Cristo Redentor";
        var city = "Rio de Janeiro";
        var uf = "RJ";
        var reference = "Parque Nacional";
        var description = "Ponto turístico famoso";

        // Act
        var entity = new TouristAttractionEntity(
            title,
            city,
            uf,
            reference,
            description,
            provider);

        // Assert
        Assert.Equal(provider.FixedGuid, entity.Id);
        Assert.Equal(provider.FixedDate, entity.CreatedAt);
        Assert.Equal(title, entity.Title);
        Assert.Equal(city, entity.City);
        Assert.Equal(uf, entity.UF);
        Assert.Equal(reference, entity.Reference);
        Assert.Equal(description, entity.Description);
        Assert.Null(entity.UpdatedAt);
    }

    [Fact]
    public void UpdateDetails_Should_Update_All_Fields_And_Set_UpdatedAt()
    {
        // Arrange
        var provider = new FakeProvider();
        var entity = new TouristAttractionEntity(
            "Título Antigo",
            "Cidade Antiga",
            "SP",
            "Referência Antiga",
            "Descrição Antiga",
            provider);

        var newTitle = "Título Novo";
        var newCity = "Nova Cidade";
        var newUf = "RJ";
        var newReference = "Nova Referência";
        var newDescription = "Nova Descrição";

        // Act
        entity.UpdateDetails(
            newTitle,
            newCity,
            newUf,
            newDescription,
            newReference);

        // Assert
        Assert.Equal(newTitle, entity.Title);
        Assert.Equal(newCity, entity.City);
        Assert.Equal(newUf, entity.UF);
        Assert.Equal(newReference, entity.Reference);
        Assert.Equal(newDescription, entity.Description);
        Assert.NotNull(entity.UpdatedAt);
    }
}