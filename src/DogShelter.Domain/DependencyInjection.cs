using DogShelter.Domain.Entities.BreedEntity.SearchUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace DogShelter.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddScoped<Search>(); // Breed(entity) » Search(use case)
    }
}