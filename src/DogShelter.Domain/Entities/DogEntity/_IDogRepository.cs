using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;

namespace DogShelter.Domain.Entities.DogEntity;

public interface IDogRepository
{
    Task<IDomainActionResult<Dog>> GetDogByNameAsync(string name);

    Task<IDomainActionResult<FlatDogResult>> AddDogAsync(AddDogParams addDogParams);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightLowerThenAsync(int maximumHeight);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightHigherThenAsync(int minimumHeight);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightBetweenAsync(int minimumHeight, int maximumHeight);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsbyBreedAsync(GetDogsByBreedParams getDogsbyBreedParams);
}
