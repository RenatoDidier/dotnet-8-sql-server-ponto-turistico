using Tourism.Domain.Common;
using Xunit;

namespace Tourism.Domain.Tests.Common;

public class ProviderTests
{
    [Fact]
    public void NewGuid_Should_Return_Non_Empty_Guid()
    {
        // Arrange
        var provider = new Provider();

        // Act
        var guid = provider.NewGuid();

        // Assert
        Assert.NotEqual(Guid.Empty, guid);
    }

    [Fact]
    public void DateTimeUtcNow_Should_Return_Utc_DateTime()
    {
        // Arrange
        var provider = new Provider();

        // Act
        var now = provider.DateTimeUtcNow();

        // Assert
        Assert.Equal(DateTimeKind.Utc, now.Kind);
    }
}