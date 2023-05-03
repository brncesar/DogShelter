using FluentValidation;

namespace DogShelter.Domain.Entities.DogEntity.GetDogsByTemperamentUseCase;

internal class GetDogsByTemperamentParamsValidator : AbstractValidator<GetDogsByTemperamentParams>
{
    public GetDogsByTemperamentParamsValidator()
    {
        RuleFor(p => p.Temperament)
            .Must(temperament => temperament.Trim().Length >= 3 && temperament.Trim().Length <= 50)
            .WithMessage(p => GetDogsByTemperamentErrors.TemperamentLengthWithoutRange().Description);
    }
}