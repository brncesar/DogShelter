using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;
using DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;
using DogShelter.Domain.Entities.DogEntity.GetDogsByTemperamentUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace DogShelter.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
        => services
            .AddScoped<AddDog>()
            .AddScoped<GetDogsByBreed>()
            .AddScoped<GetDogsByTemperament>()
            .AddScoped<FindAvailableDogsBySize>();
}