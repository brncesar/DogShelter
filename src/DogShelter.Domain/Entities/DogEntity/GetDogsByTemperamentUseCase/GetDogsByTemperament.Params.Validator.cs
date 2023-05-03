using FluentValidation;

namespace DogShelter.Domain.Entities.DogEntity.GetDogsByTemperamentUseCase;

internal class GetDogsByTemperamentParamsValidator : AbstractValidator<GetDogsByTemperamentParams>
{
    public GetDogsByTemperamentParamsValidator()
    {
        RuleFor(p => p.Temperament)
            .Must(name => name.Trim().Length >= 3 && name.Trim().Length <= 50)
            .WithMessage(p => GetDogsByTemperamentErrors.TemperamentLengthWithoutRange().Description);
    }
}