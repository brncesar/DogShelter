using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Misc;
using DogShelter.Infrastructure.Data.DbCtx;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    public async Task<IDomainActionResult<Dog>> GetDogByName(string name)
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

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightBetween(int minimumHeight, int maximumHeight)
        => await GetDogsByHeight(min: minimumHeight, max: maximumHeight);

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightHigherThen(int minimumHeight)
        => await GetDogsByHeight(min: minimumHeight);

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightLowerThen(int maximumHeight)
        => await GetDogsByHeight(max: maximumHeight);

    private async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeight(int ? min = null, int? max = null)
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