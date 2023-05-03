using FluentValidation;

namespace DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;

internal class FindAvailableDogsBySizeParamsValidator : AbstractValidator<FindAvailableDogsBySizeParams>
{
    public FindAvailableDogsBySizeParamsValidator()
    {
        RuleFor(p => p.Size)
            .Must(size => char.ToLower(size) is 's' or 'm' or 'l')
            .WithMessage(z => "To search, the size must be informed as 's', 'm', or 'l'");
    }
}