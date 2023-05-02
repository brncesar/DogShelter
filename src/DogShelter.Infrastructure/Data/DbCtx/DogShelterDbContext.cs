using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.DogEntity;
using Microsoft.EntityFrameworkCore;

namespace DogShelter.Infrastructure.Data.DbCtx;

public class DogShelterDbContext : DbContext
{
    public DogShelterDbContext(DbContextOptions<DogShelterDbContext> options) : base(options) { }

    public DbSet<Breed> Breed { get; set; } = null!;
    public DbSet<Dog  > Dog   { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #if DEBUG
        optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();
        #endif

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .RemovePluralizeConvention()
            .RemoveOneToManyCascadeConvention()
            .SetStringTypeToVarchar100AsDefault()
            .ApplyEntitiesTypeConfigurations<DogShelterDbContext>(); // DbMaps

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(100);

        base.ConfigureConventions(configurationBuilder);
    }
}