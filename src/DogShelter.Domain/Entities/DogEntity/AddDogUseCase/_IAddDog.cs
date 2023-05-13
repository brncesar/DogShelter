using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;

namespace DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

public interface IAddDog : IUseCase<AddDogParams, FlatDogResult>
{
}
