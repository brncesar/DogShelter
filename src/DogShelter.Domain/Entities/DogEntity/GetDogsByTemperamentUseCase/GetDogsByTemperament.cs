using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.DogEntity.GetDogsByTemperamentUseCase;

public class GetDogsByTemperament
{
    private readonly IDogRepository _dogRepository;

    public GetDogsByTemperament(IDogRepository dogRepository)
        => (_dogRepository) = (dogRepository);

    public async Task<IDomainActionResult<List<FlatDogResult>>> Execute(GetDogsByTemperamentParams getDogsByTemperamentParams)
    {
        var paramsValidationResult = new GetDogsByTemperamentParamsValidator().Validate(getDogsByTemperamentParams);
        var getDogsByTemperamentResult = new DomainActionResult<List<FlatDogResult>>(paramsValidationResult.Errors);

        if (paramsValidationResult.HasErrors())
            return getDogsByTemperamentResult;

        var temperamentsToSearch = GetTemperamentsFromString(getDogsByTemperamentParams.Temperament);

        var getDogsByTemperamentRespositoryResult = await _dogRepository.GetDogsByTemperamentAsync(temperamentsToSearch);

        if (getDogsByTemperamentRespositoryResult.HasErrors())
            return getDogsByTemperamentResult.AddErrors(getDogsByTemperamentRespositoryResult.Errors);

        return getDogsByTemperamentRespositoryResult.Value is not null
            ? getDogsByTemperamentResult.SetValue(getDogsByTemperamentRespositoryResult.Value)
            : getDogsByTemperamentResult;
    }

    private List<string> GetTemperamentsFromString(string inputSearch)
        => inputSearch.Replace(";", ",").Split(",").Select(p => p.Trim()).Where(x => x != string.Empty).Distinct().ToList();
}