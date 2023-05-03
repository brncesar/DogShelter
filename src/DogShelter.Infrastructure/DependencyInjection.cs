using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.DogEntity;
using DogShelter.Infrastructure.ApiClient.TheDogApi;
using DogShelter.Infrastructure.Data.DbCtx;
using DogShelter.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DogShelter.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBreedRepository, BreedRepository>();
        services.AddScoped<IDogRepository  , DogRepository  >();
        services.AddScoped<ITheDogApiClient, TheDogApiClient>();

        services.AddHttpClient("TheDogApiClient", client => {
            client.BaseAddress = new Uri(configuration["ApiClients:TheDogApi:BaseAddress"] ?? "");
            client.DefaultRequestHeaders.Add("X-Api-Key", configuration["ApiClients:TheDogApi:ApiKey"]);
        });

        services.AddDbContext<DogShelterDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DogShelterConnection")));

        return services;
    }
}
