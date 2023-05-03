using FluentValidation;

namespace DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;

internal class GetDogsByBreedParamsValidator : AbstractValidator<GetDogsByBreedParams>
{
    public GetDogsByBreedParamsValidator()
    {
        RuleFor(p => p.BreedId)
            .Must(id => id > 0)
            .WithMessage(p => DogCommonErrors.PropsErrors.BreedIdLowerThan1().Description);
    }
}