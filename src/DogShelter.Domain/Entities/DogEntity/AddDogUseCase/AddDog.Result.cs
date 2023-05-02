namespace DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

public record AddDogResult(
    Guid   Id,
    string Name,
    string BreedName,
    string BredFor,
    string BreedGroup,
    string LifeSpan,
    string Temperament,
    int    HeightAverageMetric,
    int    HeightAverageImperial);
