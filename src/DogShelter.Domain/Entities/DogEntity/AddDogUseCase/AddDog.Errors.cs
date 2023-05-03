using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

public sealed class AddDogErrors
{
    private static string className = nameof(AddDogErrors).Replace("Errors", "");

    public static Error DuplicateDog() => ErrorHelpers.GetError(ErrorType.Conflict, "There is already another dog registered with the same name.", codeError: "DogAlreadyExists");

    public static Error BreedNotFound() => ErrorHelpers.GetError(ErrorType.NotFound, "The related breed informed was not found", codeError: "BreedNotFound");
}