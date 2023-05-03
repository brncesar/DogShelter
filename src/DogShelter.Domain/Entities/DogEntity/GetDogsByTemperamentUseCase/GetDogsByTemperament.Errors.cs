using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.DogEntity.GetDogsByTemperamentUseCase;

public sealed class GetDogsByTemperamentErrors
{
    private static string className = nameof(GetDogsByTemperamentErrors).Replace("Errors", "");

    public static Error TemperamentLengthWithoutRange() => ErrorHelpers.GetError(
        ErrorType.Validation,
        "The temperament must be defined with a minimum of 3 and a maximum of 50 characters.",
        codeError: "GetDogsByTemperament.Property.Temperament.LengthWithoutRange");
}