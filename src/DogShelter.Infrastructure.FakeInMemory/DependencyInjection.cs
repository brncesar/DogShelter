using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Infrastructure.FakeInMemory.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DogShelter.Infrastructure.FakeInMemory;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureFakeInMemory(this IServiceCollection services)
    {
        services.AddScoped<IBreedRepository, BreedRepositoryMemory>();

        return services;
    }
}