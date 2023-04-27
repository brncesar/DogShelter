using DogShelter.Domain.Entities.BreedEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogShelter.Infrastructure.Data.DbCtx.DbMap;

internal class BreedDbMap : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("T?##_Breed");
        builder.HasKey  (p => p.Id);
        builder.Property(p => p.Id).HasColumnName("T?##_id_Breed").HasColumnOrder(1);/*
        builder.HasIndex(b => b.Cod).IsUnique(true);*/
        builder.Property(p => p.Id).HasMaxLength(255).IsRequired().IsFixedLength().HasColumnType("char").HasComment("Lorem ipsum dollor");
        builder.Property(p => p.ApiId).HasMaxLength(255).IsRequired().IsFixedLength().HasColumnType("char").HasComment("Lorem ipsum dollor");
        builder.Property(p => p.Name).HasMaxLength(255).IsRequired().IsFixedLength().HasColumnType("char").HasComment("Lorem ipsum dollor");
        builder.Property(p => p.BredFor).HasMaxLength(255).IsRequired().IsFixedLength().HasColumnType("char").HasComment("Lorem ipsum dollor");
        builder.Property(p => p.BreedGroup).HasMaxLength(255).IsRequired().IsFixedLength().HasColumnType("char").HasComment("Lorem ipsum dollor");
        builder.Property(p => p.LifeSpan).HasMaxLength(255).IsRequired().IsFixedLength().HasColumnType("char").HasComment("Lorem ipsum dollor");
        builder.Property(p => p.Temperament).HasMaxLength(255).IsRequired().IsFixedLength().HasColumnType("char").HasComment("Lorem ipsum dollor");
        builder.Property(p => p.Weight).HasMaxLength(255).IsRequired().IsFixedLength().HasColumnType("char").HasComment("Lorem ipsum dollor");
        builder.Property(p => p.Height).HasMaxLength(255).IsRequired().IsFixedLength().HasColumnType("char").HasComment("Lorem ipsum dollor");

        // Relationships
        /*
        builder
            .HasOne       (thisEntity  => thisEntity .NavigationProperty)
            .WithMany     (otherEntity => otherEntity.ListPropertyOfThisEntity)
            .HasForeignKey(thisEntity  => thisEntity .IdFromNavigationProperty);*/
    }
}