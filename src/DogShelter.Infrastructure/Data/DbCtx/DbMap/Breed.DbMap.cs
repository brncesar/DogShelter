using DogShelter.Domain.Entities.BreedEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogShelter.Infrastructure.Data.DbCtx.DbMap;

internal class BreedDbMap : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("T02_Breed").HasKey(p => p.Id);
        builder.Property(p => p.Id                   ).HasColumnName("T02_id_Breed").HasColumnOrder(1);
        builder.HasIndex(b => b.ApiId                ).IsUnique(true);
        builder.Property(p => p.ApiId                ).HasColumnName("id_BreedIdOnDogApi"      );
        builder.Property(p => p.Name                 ).HasColumnName("na_Breed"                ).HasMaxLength(255).IsRequired();
        builder.Property(p => p.BredFor              ).HasColumnName("tx_BredFor"              ).HasMaxLength(255).IsRequired();
        builder.Property(p => p.BreedGroup           ).HasColumnName("tx_BredGroup"            ).HasMaxLength(255).IsRequired();
        builder.Property(p => p.LifeSpan             ).HasColumnName("tx_LifeSpan"             ).HasMaxLength(255).IsRequired();
        builder.Property(p => p.Temperament          ).HasColumnName("tx_Temperament"          ).HasMaxLength(255).IsRequired();
        builder.Property(p => p.HeightAverageMetric  ).HasColumnName("nu_HeightAverageMetric"  );
        builder.Property(p => p.HeightAverageImperial).HasColumnName("nu_HeightAverageImperial");
    }
}