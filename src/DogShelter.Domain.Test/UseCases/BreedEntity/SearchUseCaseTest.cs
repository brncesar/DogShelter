using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.BreedEntity.SearchUseCase;
using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Test.UseCases.DistritoEntity;

public class SearchUseCaseTest
{
    private Search _useCaseTestTarget;
    private SearchParams _useCaseCommonParamObj = new SearchParams(
        Id: new Guid(),
        ApiId: 0,
        Name: "some valid domain value",
        BredFor: "some valid domain value",
        BreedGroup: "some valid domain value",
        LifeSpan: "some valid domain value",
        Temperament: "some valid domain value",
        Weight: "some valid domain value",
        Height: "some valid domain value");

    public SearchUseCaseTest(Search searchUseCase)
    {
        _useCaseTestTarget = searchUseCase;
    }

    [Fact]
    public async Task MustReturnErrorWhenTryingToExecuteWithoutAnyInformation()
    {
        var SearchParamsResult = await _useCaseTestTarget.Execute(_useCaseCommonParamObj);

        Assert.True(SearchParamsResult.HasErrors());
    }
}