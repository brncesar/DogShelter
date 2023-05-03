using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace DogShelter.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
        => services
            .AddScoped<AddDog>()
            .AddScoped<FindAvailableDogsBySize>();
}