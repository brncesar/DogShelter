using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;

public class FindAvailableDogsBySize : IFindAvailableDogsBySize
{
    public const int SMALL_MAX_SIZE_IN_CENTIMETERS = 35;
    public const int LARGE_MIN_SIZE_IN_CENTIMETERS = 55;

    private readonly IDogRepository _dogRepository;

    public FindAvailableDogsBySize(IDogRepository dogRepository)
        => _dogRepository = dogRepository;

    public async Task<IDomainActionResult<List<FlatDogResult>>> Execute(FindAvailableDogsBySizeParams findAvailableDogsBySizeParams)
    {
        var paramsValidationResult = new FindAvailableDogsBySizeParamsValidator().Validate(findAvailableDogsBySizeParams);
        var findAvailableDogsBySizeResult = new DomainActionResult<List<FlatDogResult>>(paramsValidationResult.Errors);

        if (paramsValidationResult.HasErrors())
            return findAvailableDogsBySizeResult;

        var findAvailableDogsBySizeRespositoryResult = char.ToLower(findAvailableDogsBySizeParams.Size) switch
        {
            's' => await _dogRepository.GetDogsByHeightLowerThenAsync (SMALL_MAX_SIZE_IN_CENTIMETERS),
            'l' => await _dogRepository.GetDogsByHeightHigherThenAsync(LARGE_MIN_SIZE_IN_CENTIMETERS),
            'm' => await _dogRepository.GetDogsByHeightBetweenAsync   (SMALL_MAX_SIZE_IN_CENTIMETERS, LARGE_MIN_SIZE_IN_CENTIMETERS),
        };

        if (findAvailableDogsBySizeRespositoryResult.HasErrors())
            return findAvailableDogsBySizeResult.AddErrors(findAvailableDogsBySizeRespositoryResult.Errors);

        return findAvailableDogsBySizeRespositoryResult.Value is not null
            ? findAvailableDogsBySizeResult.SetValue(findAvailableDogsBySizeRespositoryResult.Value)
            : findAvailableDogsBySizeResult;
    }
}