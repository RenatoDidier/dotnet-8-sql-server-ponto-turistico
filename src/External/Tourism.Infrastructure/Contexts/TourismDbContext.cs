using Microsoft.EntityFrameworkCore;
using Tourism.Domain.Entities;

namespace Tourism.Infrastructure.Contexts;

public class TourismDbContext : DbContext
{
    public TourismDbContext(DbContextOptions<TourismDbContext> options)
    : base(options) { }

    public DbSet<TouristAttractionEntity> TouristAttraction => Set<TouristAttractionEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TourismDbContext).Assembly);
    }
}
