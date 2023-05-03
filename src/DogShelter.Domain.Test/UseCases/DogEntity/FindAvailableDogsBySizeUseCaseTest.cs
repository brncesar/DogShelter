using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;

namespace DogShelter.Domain.Test.UseCases.DistritoEntity;

public class FindAvailableDogsBySizeUseCaseTest
{
    private readonly FindAvailableDogsBySize _useCaseTestTarget;
    private readonly FindAvailableDogsBySizeParams _useCaseCommonParamObj = new (
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

        const int smallMaxSize = FindAvailableDogsBySize.SMALL_MAX_SIZE_IN_CENTIMETERS;
        const int largeMinSize = FindAvailableDogsBySize.LARGE_MIN_SIZE_IN_CENTIMETERS;

        var areAllDogsConsistentSized = useCaseParamsObj.Size switch
        {
            's' => foundedDogs?.All(dog => dog.HeightAverageMetric <= smallMaxSize) ?? true,
            'l' => foundedDogs?.All(dog => dog.HeightAverageMetric >= largeMinSize) ?? true,
            'm' => foundedDogs?.All(dog => dog.HeightAverageMetric >= smallMaxSize && dog.HeightAverageMetric <= largeMinSize) ?? true,
        };

        return FindAvailableDogsBySizeParamsResult.IsSuccess() && areAllDogsConsistentSized;
    }
}
