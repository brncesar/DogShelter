using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

public class AddDog
{
    private readonly IDogRepository   _dogRepository;
    private readonly IBreedRepository _breedRepository;

    public AddDog(IDogRepository dogRepository, IBreedRepository breedRepository)
        => (_dogRepository, _breedRepository) = (dogRepository, breedRepository);

    public async Task<IDomainActionResult<FlatDogResult>> Execute(AddDogParams addDogParams)
    {
        var paramsValidationResult = new AddDogParamsValidator().Validate(addDogParams);

        var addDogResult = new DomainActionResult<FlatDogResult>(paramsValidationResult.Errors);

        await IfTheNamePropertyIsValidCheckIfThereIsAlreadyARegisteredDogWithThisName(addDogResult, addDogParams.Name);

        await IFTheBreedIdPropertyIsValidCheckIfThereIsABreedAssociatedWithTheInformedId(addDogResult, addDogParams.BreedId);

        if (addDogResult.HasErrors())
            return addDogResult;

        var addDogRespositoryResult = await _dogRepository.AddDogAsync(addDogParams);

        addDogResult.AddErrors(addDogRespositoryResult.Errors);

        return addDogResult.IsSuccess()
            ? addDogResult.SetValue(addDogRespositoryResult.Value)
            : addDogResult;
    }

    private async Task IfTheNamePropertyIsValidCheckIfThereIsAlreadyARegisteredDogWithThisName(DomainActionResult<FlatDogResult> domainActionResult, string dogName)
    {
        var dogPropertyNameLengthWithoutRange = DogCommonErrors.PropsErrors.NameLengthWithoutRange().Description;
        if (domainActionResult.Errors.None(err => err.Description == dogPropertyNameLengthWithoutRange))
        {
            if (await ThereIsAlreadyAnotherDogRegisteredWithTheSameName(dogName.Trim()))
                domainActionResult.AddError(DogCommonErrors.DuplicateDog());
        }
    }

    private async Task<bool> ThereIsAlreadyAnotherDogRegisteredWithTheSameName(string name)
    {
        var domainResultGetDogByName = await _dogRepository.GetDogByName(name);

        return domainResultGetDogByName.IsSuccess() && domainResultGetDogByName.Value is not null;
    }

    private async Task IFTheBreedIdPropertyIsValidCheckIfThereIsABreedAssociatedWithTheInformedId(DomainActionResult<FlatDogResult> domainActionResult, int breedId)
    {
        var dogPropertyBreedIdLowerThan1 = DogCommonErrors.PropsErrors.BreedIdLowerThan1().Description;
        if (domainActionResult.Errors.None(err => err.Description == dogPropertyBreedIdLowerThan1))
        {
            if (await IsntThereABreedAssociatedWithTheId(breedId))
                domainActionResult.AddError(DogCommonErrors.BreedNotFound());
        }
    }

    private async Task<bool> IsntThereABreedAssociatedWithTheId(int breedId)
    {
        var domainResultGetBreedByExternalId = await _breedRepository.GetByExternalId(breedId);

        return domainResultGetBreedByExternalId.Errors.Any(err => err.Type == ErrorType.NotFound);
    }
}