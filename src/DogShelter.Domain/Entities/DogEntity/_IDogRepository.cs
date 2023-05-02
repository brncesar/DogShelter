using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

namespace DogShelter.Domain.Entities.DogEntity;

public interface IDogRepository
{
    Task<IDomainActionResult<AddDogResult>> AddDogAsync(AddDogParams addDogParams);

    Task<IDomainActionResult<AddDogResult>> GetDogsByHeightLowerThen(int maximumHeight);

    Task<IDomainActionResult<Dog>> GetDogByName(string name);

    Task<IDomainActionResult<AddDogResult>> GetDogsByHeightBetween(int minimumHeight, int maximumHeight);

    Task<IDomainActionResult<AddDogResult>> GetDogsByHeightHigherThen(int minimumHeight);
}