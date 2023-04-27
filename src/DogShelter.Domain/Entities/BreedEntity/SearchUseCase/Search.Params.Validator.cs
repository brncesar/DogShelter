using DogShelter.Domain.Misc;
using FluentValidation;

namespace DogShelter.Domain.Entities.BreedEntity.SearchUseCase;

internal class SearchParamsValidator : AbstractValidator<SearchParams>
{
    public SearchParamsValidator()
    {
        RuleFor(p => p.Id); //.Length(2, 9);
        RuleFor(p => p.ApiId); //.Length(2, 9);
        RuleFor(p => p.Name); //.Length(2, 9);
        RuleFor(p => p.BredFor); //.Length(2, 9);
        RuleFor(p => p.BreedGroup); //.Length(2, 9);
        RuleFor(p => p.LifeSpan); //.Length(2, 9);
        RuleFor(p => p.Temperament); //.Length(2, 9);
        RuleFor(p => p.Weight); //.Length(2, 9);
        RuleFor(p => p.Height); //.Length(2, 9);

        /** SOME VALIDATIONS EXAMPLES **********************************************************************************

        RuleFor(p => p.Matricula).NotEmpty().MaximumLength(9).WithName("Matrícula com 9 dígitos");

        RuleFor(p => p.SomeStringToCastToEnum)
            .IsEnumName(typeof(SomeEnum), caseSensitive: false)
            .WithMessage(p => $"SomeEnum `'{p.SomeStringToCastToEnum}`' inválida. Os valores possíveis são: {string.Join(", ", Enum.GetValues(typeof(SomeEnum)).Cast<SomeEnum>())}");

        RuleFor(p => new { p.Nome, p.Codigo })
            .Must(x => x.Codigo.IsNotNullOrNotEmpty() || x.Nome.IsNotNullOrNotEmpty())
            .WithMessage(z => $"É necessário informar pelo menos um parâmetro para busca do Distrito [ Nome | Código ]");

        var beAValidLongitude = (double longitude) => longitude is >= -90 and <= 90;
        RuleFor(p => p.Longitude).Must(beAValidLongitude)
            .WithMessage(p =>
                $"Longitude inválida. O valor deve estar compreendido entre -180 e 180." +
                $"O valor informado foi: {p.Longitude}");

        RuleFor(p => p.NumeroRegistro).Matches("[0-9]{4}[-][0-9]")
            .WithMessage(p =>
                $"O número do registro da feira deve ser informado no formato ####-#. " +
                $"O valor informado foi: {p.NumeroRegistro}");

        For more examples go to: https://docs.fluentvalidation.net/en/latest/built-in-validators.html
        ************************************************************************************************************* */
    }
}