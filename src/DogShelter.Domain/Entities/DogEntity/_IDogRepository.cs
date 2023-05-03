using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

namespace DogShelter.Domain.Entities.DogEntity;

public interface IDogRepository
{
    Task<IDomainActionResult<Dog>> GetDogByName(string name);

    Task<IDomainActionResult<FlatDogResult>> AddDogAsync(AddDogParams addDogParams);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightLowerThen(int maximumHeight);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightHigherThen(int minimumHeight);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightBetween(int minimumHeight, int maximumHeight);
}
