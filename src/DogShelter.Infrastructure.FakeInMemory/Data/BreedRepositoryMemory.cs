using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.BreedEntity.SearchUseCase;

namespace DogShelter.Infrastructure.FakeInMemory.Data;

public class BreedRepositoryMemory : IBreedRepository
{
    private List<Breed> ListBreedMock { get; }

    public BreedRepositoryMemory()
    {
        ListBreedMock = new List<Breed>{
            new Breed {
                 Id = new Guid("81b9f6fc-e489-11ed-b5ea-0242ac120001"),
                 ApiId = 18,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81b9f83c-e489-11ed-b5ea-0242ac120002"),
                 ApiId = 32,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81b9f972-e489-11ed-b5ea-0242ac120003"),
                 ApiId = 54,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81b9fed6-e489-11ed-b5ea-0242ac120004"),
                 ApiId = 47,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba014c-e489-11ed-b5ea-0242ac120005"),
                 ApiId = 10,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba0296-e489-11ed-b5ea-0242ac120006"),
                 ApiId = 93,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba0426-e489-11ed-b5ea-0242ac120007"),
                 ApiId = 3,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba0552-e489-11ed-b5ea-0242ac120008"),
                 ApiId = 6,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba066a-e489-11ed-b5ea-0242ac120009"),
                 ApiId = 69,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba0796-e489-11ed-b5ea-0242ac120010"),
                 ApiId = 81,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba08e0-e489-11ed-b5ea-0242ac120011"),
                 ApiId = 27,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba0e12-e489-11ed-b5ea-0242ac120012"),
                 ApiId = 50,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba0f52-e489-11ed-b5ea-0242ac120013"),
                 ApiId = 46,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba1074-e489-11ed-b5ea-0242ac120014"),
                 ApiId = 8,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba11a0-e489-11ed-b5ea-0242ac120015"),
                 ApiId = 92,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba12cc-e489-11ed-b5ea-0242ac120016"),
                 ApiId = 70,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba13f8-e489-11ed-b5ea-0242ac120017"),
                 ApiId = 72,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba1510-e489-11ed-b5ea-0242ac120018"),
                 ApiId = 40,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81ba161e-e489-11ed-b5ea-0242ac120019"),
                 ApiId = 89,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" },
            new Breed {
                 Id = new Guid("81b9f422-e489-11ed-b5ea-0242ac120020"),
                 ApiId = 68,
                 Name = "some valid domain value",
                 BredFor = "some valid domain value",
                 BreedGroup = "some valid domain value",
                 LifeSpan = "some valid domain value",
                 Temperament = "some valid domain value",
                 Weight = "some valid domain value",
                 Height = "some valid domain value" }
        };
    }/*

    public async Task<IDomainActionResult<Breed>> USE_CASE_EXEMPLE_GetByCodigoAsync(string codigo)
    {
        var breed = ListBreedMock.SingleOrDefault(f => f.Codigo == codigo.Trim());

        var domainRepositoryResult = new DomainActionResult<Breed>(breed);

        return breed is not null
            ? domainRepositoryResult
            : domainRepositoryResult.AddNotFoundError($"{nameof(BreedRepositoryMemory)}.{nameof(GetByIdAsync)}", "Breed não encontrado");
    }*/

    public Task<IDomainActionResult<SearchResult>> SearchAsync(SearchParams searchParams)
    {
        throw new NotImplementedException();
    }

    public Task<IDomainActionResult<Breed>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IDomainActionResult<Guid>> AddAsync(Breed entity)
    {
        throw new NotImplementedException();
    }

    public Task<IDomainActionResult<bool>> UpdateAsync(Breed entity)
    {
        throw new NotImplementedException();
    }

    public Task<IDomainActionResult<bool>> DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IDomainActionResult<List<Breed>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}