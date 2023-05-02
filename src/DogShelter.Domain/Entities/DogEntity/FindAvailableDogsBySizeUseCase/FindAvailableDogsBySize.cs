using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;

public class FindAvailableDogsBySize
{
    private readonly IDogRepository _dogRepository;

    public FindAvailableDogsBySize(IDogRepository dogRepository)
        => _dogRepository = dogRepository;

    public async Task<IDomainActionResult<List<FlatDogResult>>> Execute(FindAvailableDogsBySizeParams findAvailableDogsBySizeParams)
    {
        var paramsValidationResult = new FindAvailableDogsBySizeParamsValidator().Validate(findAvailableDogsBySizeParams);
        var findAvailableDogsBySizeResult = new DomainActionResult<List<FlatDogResult>>(paramsValidationResult.Errors);

        if (paramsValidationResult.HasErrors())
            return findAvailableDogsBySizeResult;

        var sizeLimits = GetMeasurementsAccordingToTheUnitOfMeasurement(findAvailableDogsBySizeParams);

        var findAvailableDogsBySizeRespositoryResult = findAvailableDogsBySizeParams.Size switch
        {
            's' => await _dogRepository.GetDogsByHeightLowerThen (findAvailableDogsBySizeParams.IsMeasurementSystemMetric, sizeLimits.smallMaxSize),
            'l' => await _dogRepository.GetDogsByHeightHigherThen(findAvailableDogsBySizeParams.IsMeasurementSystemMetric, sizeLimits.largeMinSize),
            'm' => await _dogRepository.GetDogsByHeightBetween   (findAvailableDogsBySizeParams.IsMeasurementSystemMetric, sizeLimits.smallMaxSize, sizeLimits.largeMinSize),
        };

        if (findAvailableDogsBySizeRespositoryResult.HasErrors())
            return findAvailableDogsBySizeResult.AddErrors(findAvailableDogsBySizeRespositoryResult.Errors);

        return findAvailableDogsBySizeRespositoryResult.Value is not null
            ? findAvailableDogsBySizeResult.SetValue(findAvailableDogsBySizeRespositoryResult.Value)
            : findAvailableDogsBySizeResult;
    }

    public static (int smallMaxSize, int largeMinSize) GetMeasurementsAccordingToTheUnitOfMeasurement(FindAvailableDogsBySizeParams findAvailableDogsBySizeParams)
    {
        const int smallMaxSizeCm = 35;
        const int largeMinSizeCm = 55;

        int smallMaxSizeIn = (int)Math.Round(smallMaxSizeCm * 0.393701, 0);
        int largeMinSizeIn = (int)Math.Round(largeMinSizeCm * 0.393701, 0);

        int smallMaxSize = findAvailableDogsBySizeParams.IsMeasurementSystemMetric
            ? smallMaxSizeCm
            : smallMaxSizeIn;

        int largeMinSize = findAvailableDogsBySizeParams.IsMeasurementSystemMetric
            ? largeMinSizeCm
            : largeMinSizeIn;

        return (smallMaxSize, largeMinSize);
    }
}