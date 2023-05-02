using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

namespace DogShelter.Domain.Test.UseCases.DistritoEntity;

public class AddDogUseCaseTest
{
    private readonly AddDog _useCaseTestTarget;
    private readonly AddDogParams _useCaseCommonParamObj = new AddDogParams(
        Name: "Vira lata",
        BreedId: 6);

    public AddDogUseCaseTest(AddDog addDogUseCase) => _useCaseTestTarget = addDogUseCase;

    [Theory]
    [InlineData(1001)]
    [InlineData(2000)]
    [InlineData(3000)]
    [InlineData(4000)]
    // The mock repository returns NotFound if the breedId is greater than 1000.
    public async Task MustReturnErrorWhenBreedDoesntExist(int breedId)
    {
        var useCaseParamObj = _useCaseCommonParamObj with
        {
            BreedId  = breedId
        };

        var addNewDogResult = await _useCaseTestTarget.Execute(useCaseParamObj);

        var hasErrorBreedNotFound = addNewDogResult.Errors.Any(err => err.Description == AddDogErrors.BreedNotFound().Description);

        Assert.True(hasErrorBreedNotFound);
    }

    [Fact]
    public async Task MustReturnErrorWhenTryingToAddADogThatAlreadyHaveTheSameName()
    {
        var dogName = _useCaseCommonParamObj.Name + DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        var useCaseParamObj = _useCaseCommonParamObj with
        {
            Name = dogName
        };

        var addNewDogResult = await _useCaseTestTarget.Execute(useCaseParamObj);

        Assert.True(addNewDogResult.IsSuccess());

        var anotherNewDogWithTheSameName = await _useCaseTestTarget.Execute(useCaseParamObj);

        var hasDuplicateDogError = anotherNewDogWithTheSameName.Errors.Any(err => err.Description == AddDogErrors.DuplicateDog().Description);

        Assert.True(hasDuplicateDogError);
    }
}