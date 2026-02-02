using Tourism.Domain.Common;
using Tourism.Domain.Interfaces;
using Tourism.Domain.Test.Fakes;
using Xunit;

namespace Tourism.Domain.Tests.Common;

public class BaseEntityTests
{
    [Fact]
    public void Constructor_Should_Set_Id_Title_And_CreatedAt()
    {
        // Arrange
        var provider = new FakeProvider();
        var title = "Título teste";

        // Act
        var entity = new TestEntity(title, provider);

        // Assert
        Assert.Equal(provider.FixedGuid, entity.Id);
        Assert.Equal(title, entity.Title);
        Assert.Equal(provider.FixedDate, entity.CreatedAt);
        Assert.Null(entity.UpdatedAt);
    }

    [Fact]
    public void UpdateTitle_Should_Update_Title_And_Set_UpdatedAt()
    {
        // Arrange
        var provider = new FakeProvider();
        var entity = new TestEntity("Título antigo", provider);
        var newTitle = "Novo Título";

        // Act
        entity.UpdateTitle(newTitle);

        // Assert
        Assert.Equal(newTitle, entity.Title);
        Assert.NotNull(entity.UpdatedAt);
    }

    private sealed class TestEntity : BaseEntity
    {
        public TestEntity(string title, IProvider provider)
            : base(title, provider)
        {
        }
    }
}