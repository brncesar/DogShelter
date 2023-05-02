using DogShelter.Domain.Entities.DogEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogShelter.Infrastructure.Data.DbCtx.DbMap;

internal class DogDbMap : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.ToTable("T01_Dog").HasKey(p => p.Id);
        builder.Property(p => p.Id     ).HasColumnName("T01_id_Dog"  ).HasColumnOrder(1);
        builder.Property(p => p.BreedId).HasColumnName("T02_id_Breed");
        builder.Property(p => p.Name   ).HasColumnName("na_Dog"      ).HasMaxLength(50).IsRequired();
        builder.HasIndex(b => b.Name   ).IsUnique(true);

        // Relationships
        builder
            .HasOne       (thisEntity  => thisEntity .Breed  )
            .WithMany     (otherEntity => otherEntity.Dogs   )
            .HasForeignKey(thisEntity  => thisEntity .BreedId);
    }
}