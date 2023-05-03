using DogShelter.Domain.Entities.DogEntity.GetDogsByTemperamentUseCase;

namespace DogShelter.Domain.Test.UseCases.DistritoEntity;

public class GetDogsByTemperamentUseCaseTest
{
    private readonly GetDogsByTemperament _useCaseTestTarget;
    private readonly GetDogsByTemperamentParams _useCaseCommonParamObj = new GetDogsByTemperamentParams(
        Temperament: "Friendly");

    public GetDogsByTemperamentUseCaseTest(GetDogsByTemperament getDogsByTemperamentUseCase)
        => _useCaseTestTarget = getDogsByTemperamentUseCase;

    [Fact]
    public async Task ShouldReturnEmptyListWhenTemperamentNotFound()
    {
        var useCaseSpecificParamObj = _useCaseCommonParamObj with { Temperament = "Amigável" };

        var getDogsbyBreedResult = await _useCaseTestTarget.Execute(useCaseSpecificParamObj);

        Assert.True(!getDogsbyBreedResult.Value.Any());
    }
}