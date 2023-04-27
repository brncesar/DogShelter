using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.BreedEntity.SearchUseCase;

namespace DogShelter.Domain.Entities.BreedEntity;

public interface IBreedRepository :
    IBaseEntityRepositoryGetById<Breed>,
    IBaseEntityRepositoryAdd<Breed>,
    IBaseEntityRepositoryUpdate<Breed>,
    IBaseEntityRepositoryDelete<Breed>,
    IBaseEntityRepositoryGetAll<Breed>/*,
    IBaseEntityRepositoryAllCrudOperations<Breed>*/
{/*
    Task<IDomainActionResult<Breed>> ExampleOfAnExistingMethodAsync();
    Task<IDomainActionResult<Breed>> ExampleOfAnotherExistingMethodAsync(string loremParameter);
    Task<IDomainActionResult<List<Breed>>> LastExampleOfAPreExistingMethodAsync(int ipsumParameter);*/
    // 👆 Other pre-existing methods. It`'s just an example
    // 👇 Method for your use case.
    Task<IDomainActionResult<SearchResult>> SearchAsync(SearchParams searchParams);
}