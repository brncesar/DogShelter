using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;

public sealed class GetDogsByBreedErrors
{
    private static string className = nameof(GetDogsByBreedErrors).Replace("Errors", "");

    public static Error BreedNotFound() => ErrorHelpers.GetError(ErrorType.NotFound, "The related breed informed was not found", codeError: "BreedNotFound");
}