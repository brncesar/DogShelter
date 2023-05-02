using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

namespace DogShelter.Domain.Entities.DogEntity;

public interface IDogRepository
{
    Task<IDomainActionResult<Dog>> GetDogByName(string name);

    Task<IDomainActionResult<FlatDogResult>> AddDogAsync(AddDogParams addDogParams);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightLowerThen(bool isMeasurementSystemMetric, int maximumHeight);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightHigherThen(bool isMeasurementSystemMetric, int minimumHeight);

    Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightBetween(bool isMeasurementSystemMetric, int minimumHeight, int maximumHeight);
}
