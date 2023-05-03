using FluentValidation;

namespace DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

internal class AddDogParamsValidator : AbstractValidator<AddDogParams>
{
    public AddDogParamsValidator()
    {
        RuleFor(p => p.Name)
            .Must(name => name.Trim().Length >= 3 && name.Trim().Length <= 50)
            .WithMessage(p => DogCommonErrors.PropsErrors.NameLengthWithoutRange().Description);

        RuleFor(p => p.BreedId)
            .Must(id => id > 0)
            .WithMessage(p => DogCommonErrors.PropsErrors.BreedIdLowerThan1().Description);
    }
}