using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;

public class GetDogsByBreed
{
    private readonly IDogRepository _dogRepository;

    public GetDogsByBreed(IDogRepository dogRepository)
        => (_dogRepository) = (dogRepository);

    public async Task<IDomainActionResult<List<FlatDogResult>>> Execute(GetDogsByBreedParams getDogsByBreedParams)
    {
        var paramsValidationResult = new GetDogsByBreedParamsValidator().Validate(getDogsByBreedParams);
        var getDogsbyBreedResult = new DomainActionResult<List<FlatDogResult>>(paramsValidationResult.Errors);

        if (paramsValidationResult.HasErrors())
            return getDogsbyBreedResult;

        var getDogsbyBreedRespositoryResult = await _dogRepository.GetDogsbyBreedAsync(getDogsByBreedParams);

        if (getDogsbyBreedRespositoryResult.HasErrors())
            return getDogsbyBreedResult.AddErrors(getDogsbyBreedRespositoryResult.Errors);

        return getDogsbyBreedRespositoryResult.Value is not null
            ? getDogsbyBreedResult.SetValue(getDogsbyBreedRespositoryResult.Value)
            : getDogsbyBreedResult;
    }
}