using DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;

namespace DogShelter.Domain.Test.UseCases.DistritoEntity;

public class GetDogsbyBreedUseCaseTest
{
    private readonly GetDogsByBreed _useCaseTestTarget;
    private readonly GetDogsByBreedParams _useCaseCommonParamObj = new GetDogsByBreedParams(
        BreedId: 100);

    public GetDogsbyBreedUseCaseTest(GetDogsByBreed getDogsbyBreedUseCase)
    {
        _useCaseTestTarget = getDogsbyBreedUseCase;
    }

    [Theory]
    [InlineData(1001)]
    [InlineData(2000)]
    [InlineData(3000)]
    [InlineData(4000)]
    // The mock repository returns NotFound if the breedId is greater than 1000.
    public async Task MustReturnEmptyResultWhenBreedDoesntExist(int breedId)
    {
        var useCaseParamObj = _useCaseCommonParamObj with
        {
            BreedId = breedId
        };

        var getDogsbyBreedResult = await _useCaseTestTarget.Execute(useCaseParamObj);

        Assert.True(!getDogsbyBreedResult?.Value?.Any() ?? false);
    }
}