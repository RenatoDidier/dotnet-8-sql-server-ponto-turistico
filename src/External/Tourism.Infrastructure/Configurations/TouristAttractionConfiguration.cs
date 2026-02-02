using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourism.Domain.Entities;

namespace Tourism.Infrastructure.Configurations;

public class TouristAttractionConfiguration : IEntityTypeConfiguration<TouristAttractionEntity>
{
    public void Configure(EntityTypeBuilder<TouristAttractionEntity> builder)
    {
        builder.ToTable("TouristAttractions");

        builder.HasKey(x => x.Id)
               .HasName("PK_TouristAttractions");

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.Title)
               .HasMaxLength(TouristAttractionEntity.TITLE_MAX_LENGTH)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(TouristAttractionEntity.DESCRIPTION_MAX_LENGTH)
               .IsRequired();

        builder.Property(x => x.UF)
               .HasMaxLength(TouristAttractionEntity.UF_MAX_LENGTH)
               .IsRequired();

        builder.Property(x => x.City)
               .HasMaxLength(TouristAttractionEntity.CITY_MAX_LENGTH)
               .IsRequired();

        builder.Property(x => x.Reference)
               .HasMaxLength(TouristAttractionEntity.REFERENCE_MAX_LENGTH)
               .IsRequired();

        builder.Property(x => x.CreatedAt)
               .IsRequired();

        builder.Property(x => x.UpdatedAt);
    }
}
