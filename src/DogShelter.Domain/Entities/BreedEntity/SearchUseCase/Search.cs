using DogShelter.Domain.Common;
using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.BreedEntity.SearchUseCase;

public class Search
{
    private readonly IBreedRepository _breedRepository;

    public Search(IBreedRepository breedRepository)
        => (_breedRepository) = (breedRepository);

    public async Task<IDomainActionResult<SearchResult>> Execute(SearchParams searchParams)
    {
        var paramsValidationResult = new SearchParamsValidator().Validate(searchParams);
        var searchResult = new DomainActionResult<SearchResult>(paramsValidationResult.Errors);

        if (paramsValidationResult.HasErrors())
            return searchResult;

        var searchRespositoryResult = await _breedRepository.SearchAsync(searchParams);

        if (searchRespositoryResult.HasErrors())
            return searchResult.AddErrors(searchRespositoryResult.Errors);

        return searchRespositoryResult.Value is not null
            ? searchResult.SetValue(searchRespositoryResult.Value)
            : searchResult;
    }
}