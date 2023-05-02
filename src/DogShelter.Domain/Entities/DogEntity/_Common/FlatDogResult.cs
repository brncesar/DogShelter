namespace DogShelter.Domain.Entities.DogEntity.Common;

public record FlatDogResult(
    Guid Id,
    string Name,
    string BreedName,
    string BredFor,
    string BreedGroup,
    string LifeSpan,
    string Temperament,
    int HeightAverageMetric,
    int HeightAverageImperial);
