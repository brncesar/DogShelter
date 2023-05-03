using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Misc;
using DogShelter.Infrastructure.Data.DbCtx;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;
using DogShelter.Domain.Entities.DogEntity.GetDogsByTemperamentUseCase;

namespace DogShelter.Infrastructure.Data.Repository;

public class DogRepository : BaseRepository<DogShelterDbContext, Dog>, IDogRepository
{
    private readonly IBreedRepository _breedRepository;

    public DogRepository(DogShelterDbContext dbCtx, IBreedRepository breedRepository) : base(dbCtx)
        => _breedRepository = breedRepository;

    public async Task<IDomainActionResult<FlatDogResult>> AddDogAsync(AddDogParams addDogParams)
    {
        var domainRepositoryResult = new DomainActionResult<FlatDogResult>();
        try
        {
            var getBreedByIdResult = await _breedRepository.GetByExternalId(addDogParams.BreedId);

            if (getBreedByIdResult.HasErrors())
                return domainRepositoryResult.AddErrors(getBreedByIdResult.Errors);

            var newDog = new Dog
            {
                Name = addDogParams.Name,
                BreedId = getBreedByIdResult.Value.Id
            };

            await base.AddAsync(newDog);

            var result = getFlatDogResultFromDogEntity(newDog);

            return new DomainActionResult<FlatDogResult>(result);
        }
        catch (Exception ex)
        {
            return domainRepositoryResult.ReturnRepositoryError(ex);
        }
    }

    public async Task<IDomainActionResult<Dog>> GetDogByNameAsync(string name)
    {
        var domainRepositoryResult = new DomainActionResult<Dog>();
        try
        {
            var foundedDog = await _dbSet.FirstOrDefaultAsync(d => d.Name.ToLower() == name.Trim().ToLower());

            return foundedDog is not null
                ? domainRepositoryResult.SetValue(foundedDog)
                : domainRepositoryResult.NotFound();
        }
        catch (Exception ex)
        {
            return domainRepositoryResult.ReturnRepositoryError(ex);
        }
    }

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsbyBreedAsync(GetDogsByBreedParams getDogsbyBreedParams)
    {
        var domainRepositoryResult = new DomainActionResult<List<FlatDogResult>>();
        try
        {
            var foundedDogsOnRepository = _dbSet.Where(dog => dog.Breed.ApiId == getDogsbyBreedParams.BreedId).Include(dog => dog.Breed);

            var foundedDogsListResult = new List<FlatDogResult>();

            foundedDogsOnRepository.ToList().ForEach(dog => foundedDogsListResult.Add(getFlatDogResultFromDogEntity(dog)));

            return domainRepositoryResult.SetValue(foundedDogsListResult);
        }
        catch (Exception ex)
        {
            return domainRepositoryResult.ReturnRepositoryError(ex);
        }
    }

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByTemperamentAsync(List<string> temperaments)
    {
        var domainRepositoryResult = new DomainActionResult<List<FlatDogResult>>();
        try
        {
            var filteredDogsByTemperament = new List<Dog>();

            var allDogs = _dbSet.Include(dog => dog.Breed).ToList();

            allDogs.ForEach( dog => {
                if (temperaments.Any(temp => dog.Breed.Temperament.Contains(temp)))
                    filteredDogsByTemperament.Add(dog);
            });

            var foundedDogsListResult = new List<FlatDogResult>();

            filteredDogsByTemperament.Distinct().ToList().ForEach(dog => foundedDogsListResult.Add(getFlatDogResultFromDogEntity(dog)));

            return domainRepositoryResult.SetValue(foundedDogsListResult);
        }
        catch (Exception ex)
        {
            return domainRepositoryResult.ReturnRepositoryError(ex);
        }
    }

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightBetweenAsync(int minimumHeight, int maximumHeight)
        => await GetDogsByHeightAsync(min: minimumHeight, max: maximumHeight);

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightHigherThenAsync(int minimumHeight)
        => await GetDogsByHeightAsync(min: minimumHeight);

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightLowerThenAsync(int maximumHeight)
        => await GetDogsByHeightAsync(max: maximumHeight);

    private async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightAsync(int ? min = null, int? max = null)
    {
        var domainRepositoryResult = new DomainActionResult<List<FlatDogResult>>();
        try
        {
            var heightLimits = new { Min = min, Max = max };

            Expression<Func<Dog, bool>> filter = heightLimits switch
            {
                { Min: int _min, Max: int _max } => d => d.Breed.HeightAverageMetric >= min && d.Breed.HeightAverageMetric <= max,

                { Min: int _min, Max: null     } => d => d.Breed.HeightAverageMetric >= min,

                { Min: null    , Max: int _max } => d => d.Breed.HeightAverageMetric <= max,

                _ => throw new ArgumentException()
            };

            var foundedDogsOnRepository = _dbSet.Where(filter).Include(dog => dog.Breed);

            var foundedDogsListResult = new List<FlatDogResult>();

            foundedDogsOnRepository.ToList().ForEach(dog => foundedDogsListResult.Add(getFlatDogResultFromDogEntity(dog)));

            return domainRepositoryResult.SetValue(foundedDogsListResult);
        }
        catch (Exception ex)
        {
            return domainRepositoryResult.ReturnRepositoryError(ex);
        }
    }

    private FlatDogResult getFlatDogResultFromDogEntity(Dog dogEntity)
        => new FlatDogResult(
            dogEntity.Id,
            dogEntity.Name,
            dogEntity.Breed.Name,
            dogEntity.Breed.BredFor,
            dogEntity.Breed.BreedGroup,
            dogEntity.Breed.LifeSpan,
            dogEntity.Breed.Temperament,
            dogEntity.Breed.HeightAverageMetric,
            dogEntity.Breed.HeightAverageImperial);
}