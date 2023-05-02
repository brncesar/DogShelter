using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.DogEntity;

public sealed class DogCommonErrors
{
    private static string className = nameof(DogCommonErrors).Replace("Errors", "");

    public struct PropsErrors
    {
        public static Error NameDuplicated() => ErrorHelpers.GetError(
            ErrorType.Validation,
            "There is already another dog registered with the same name.",
            codeError: "Dog.Property.Name.Duplicated");

        public static Error NameLengthWithoutRange() => ErrorHelpers.GetError(
            ErrorType.Validation,
            "The dog's name must be defined with a minimum of 3 and a maximum of 50 characters.",
            codeError: "Dog.Property.Name.LengthWithoutRange");

        public static Error BreedIdLowerThan1() => ErrorHelpers.GetError(
            ErrorType.Validation,
            "BreedId must be grater then zero.",
            codeError: "Dog.Property.BreedId.LowerThan1");
    }

    public static Error DuplicateDog() => ErrorHelpers.GetError(
        ErrorType.Conflict,
        "There is already another dog registered with the same name.",
        codeError: "DogAlreadyExists");

    public static Error BreedNotFound() => ErrorHelpers.GetError(
        ErrorType.NotFound,
        "The related breed informed was not found",
        codeError: "BreedNotFound");

    public static Error RepositoryError(string description) => ErrorHelpers.GetError(
        ErrorType.Unexpected,
        description
        /*, className, "RepositoryError"*/);
}