using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Entities.DogEntity.GetDogsByTemperamentUseCase;

namespace DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

public interface IGetDogsByTemperament : IUseCase<GetDogsByTemperamentParams, List<FlatDogResult>>
{
}
