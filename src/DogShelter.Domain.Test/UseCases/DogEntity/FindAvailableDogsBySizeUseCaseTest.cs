using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;

namespace DogShelter.Domain.Test.UseCases.DistritoEntity;

public class FindAvailableDogsBySizeUseCaseTest
{
    private readonly FindAvailableDogsBySize _useCaseTestTarget;
    private readonly FindAvailableDogsBySizeParams _useCaseCommonParamObj = new (
        IsMeasurementSystemMetric: true,
        Size: 'm');

    public FindAvailableDogsBySizeUseCaseTest(FindAvailableDogsBySize findAvailableDogsBySizeUseCase)
        => _useCaseTestTarget = findAvailableDogsBySizeUseCase;

    [Fact]
    public async Task ShouldOnlyReturnSmallBreedDogs()
    {
        var useCaseSpecificParamObj = _useCaseCommonParamObj with { Size = 's' };
        Assert.True(await AreAllFoundDogsConsistentWithTheSizeDefinedInTheFilter(useCaseSpecificParamObj));
    }

    [Fact]
    public async Task ShouldOnlyReturnMediumBreedDogs()
    {
        var useCaseSpecificParamObj = _useCaseCommonParamObj with { Size = 'm' };
        Assert.True(await AreAllFoundDogsConsistentWithTheSizeDefinedInTheFilter(useCaseSpecificParamObj));
    }

    [Fact]
    public async Task ShouldOnlyReturnLargeBreedDogs()
    {
        var useCaseSpecificParamObj = _useCaseCommonParamObj with { Size = 'l' };
        Assert.True(await AreAllFoundDogsConsistentWithTheSizeDefinedInTheFilter(useCaseSpecificParamObj));
    }

    private async Task<bool> AreAllFoundDogsConsistentWithTheSizeDefinedInTheFilter(FindAvailableDogsBySizeParams useCaseParamsObj)
    {
        var FindAvailableDogsBySizeParamsResult = await _useCaseTestTarget.Execute(useCaseParamsObj);

        var foundedDogs = FindAvailableDogsBySizeParamsResult.Value;

        var sizeLimits = FindAvailableDogsBySize.GetMeasurementsAccordingToTheUnitOfMeasurement(useCaseParamsObj);

        var areAllDogsConsistentSized = useCaseParamsObj.Size switch
        {
            's' => foundedDogs?.All(dog => dog.HeightAverageMetric <= sizeLimits.smallMaxSize) ?? true,
            'l' => foundedDogs?.All(dog => dog.HeightAverageMetric >= sizeLimits.largeMinSize) ?? true,
            'm' => foundedDogs?.All(dog => dog.HeightAverageMetric >= sizeLimits.smallMaxSize && dog.HeightAverageMetric <= sizeLimits.largeMinSize) ?? true,
        };

        return FindAvailableDogsBySizeParamsResult.IsSuccess() && areAllDogsConsistentSized;
    }
}
