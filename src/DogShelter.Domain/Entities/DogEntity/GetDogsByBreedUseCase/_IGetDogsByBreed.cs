using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;

namespace DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

public interface IGetDogsByBreed : IUseCase<GetDogsByBreedParams, List<FlatDogResult>>
{
}
