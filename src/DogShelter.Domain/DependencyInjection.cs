using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace DogShelter.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddScoped<AddDog>();
    }
}
