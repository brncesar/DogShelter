using DogShelter.Domain.Common;
using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.BreedEntity.SearchUseCase;
using DogShelter.Domain.Misc;
using DogShelter.Infrastructure.Data.DbCtx;
using Microsoft.EntityFrameworkCore;

namespace DogShelter.Infrastructure.Data.Repository;

public class BreedRepository : BaseRepository<DogShelterDbContext, Breed>, IBreedRepository
{
    public BreedRepository(DogShelterDbContext dbCtx) : base(dbCtx) { }/*

    public async Task<IDomainActionResult<SearchResult>> JUST_AN_EXAMPLE_GetByCodigoAsync(string codigo)
    {
        var domainRepositoryResult = new DomainActionResult<SearchResult>();
        try
        {
            var breed = await _dbSet.FirstOrDefaultAsync(d => d.Cod == codigo.Trim());

            return breed is not null
                ? domainRepositoryResult.SetValue(breed)
                : domainRepositoryResult.NotFound();
        }
        catch (Exception ex)
        {
            return domainRepositoryResult.ReturnRepositoryError(ex);
        }
    }*/
    // 👆 Other methods pre-defined in the Breed repository file
    // 👇 Your new method in the repository to match the use case
    public async Task<IDomainActionResult<SearchResult>> SearchAsync(SearchParams searchParams)
    {
        var domainRepositoryResult = new DomainActionResult<SearchResult>();
        try
        {
            // repository logic

            return domainRepositoryResult;
        }
        catch (Exception ex)
        {
            return domainRepositoryResult.ReturnRepositoryError(ex);
        }
    }
}