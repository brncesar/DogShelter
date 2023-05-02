namespace DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

public record AddDogParams(
    string Name,
    int BreedId);
