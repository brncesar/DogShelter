namespace DogShelter.Domain.Entities.BreedEntity.SearchUseCase;

public record SearchResult(
    Guid Id,
    int ApiId,
    string Name,
    string BredFor,
    string BreedGroup,
    string LifeSpan,
    string Temperament,
    string Weight,
    string Height);
