using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DogShelter.Infrastructure.Data.DbCtx;

public class DogShelterDbContextFactory : IDesignTimeDbContextFactory<DogShelterDbContext>
{
    private readonly IConfiguration? _configuration;

    public DogShelterDbContextFactory(IConfiguration configuration) => _configuration = configuration;

    public DogShelterDbContextFactory(){}

    public DogShelterDbContext CreateDbContext(string[] args)
    {
        string filePath = TryGetSolutionDirectoryInfo() + @"\DogShelter.Infrastructure\appsettings.json";

        IConfiguration Configuration = new ConfigurationBuilder()
           .SetBasePath(Path.GetDirectoryName(filePath))
           .AddJsonFile("appSettings.json")
           .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DogShelterDbContext>();
        optionsBuilder.UseSqlite(
            Configuration.GetConnectionString("DogShelterConnection"),
            x => x.MigrationsHistoryTable("TC00_EFMigrationsHistory"));

        return new DogShelterDbContext(optionsBuilder.Options);
    }

    private static DirectoryInfo? TryGetSolutionDirectoryInfo(string? currentPath = null)
    {
        var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
        while (directory != null && !directory.GetFiles("*.sln").Any())
            directory = directory.Parent;

        return directory;
    }
}
