using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;
using Tourism.Infrastructure.Contexts;

public sealed class SqlServerFixture : IAsyncLifetime
{
    private readonly MsSqlContainer _container;

    public string ConnectionString => _container.GetConnectionString();

    public SqlServerFixture()
    {
        _container = new MsSqlBuilder()
            .WithPassword("YourStrong@Password")
            .WithCleanUp(true)
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();

        var options = new DbContextOptionsBuilder<TourismDbContext>()
            .UseSqlServer(ConnectionString)
            .Options;

        using var context = new TourismDbContext(options);

        await context.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        await _container.DisposeAsync();
    }
}