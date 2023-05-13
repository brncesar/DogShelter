using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;

namespace DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

public interface IFindAvailableDogsBySize : IUseCase<FindAvailableDogsBySizeParams, List<FlatDogResult>>
{
}
