namespace DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;

public record FindAvailableDogsBySizeParams(
    bool IsMeasurementSystemMetric,
    char Size);
