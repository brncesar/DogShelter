using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Misc;
using DogShelter.Infrastructure.Data.DbCtx;

namespace DogShelter.Infrastructure.Data.Repository;

public class DogRepository : BaseRepository<DogShelterDbContext, Dog>, IDogRepository
{
    private readonly IBreedRepository _breedRepository;

    public DogRepository(DogShelterDbContext dbCtx, IBreedRepository breedRepository) : base(dbCtx) {
        _breedRepository = breedRepository;
    }

    public async Task<IDomainActionResult<AddDogResult>> AddDogAsync(AddDogParams addDogParams)
    {
        var domainRepositoryResult = new DomainActionResult<AddDogResult>();
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

            var result = new AddDogResult(
                newDog.Id,
                newDog.Name,
                newDog.Breed.Name,
                newDog.Breed.BredFor,
                newDog.Breed.BreedGroup,
                newDog.Breed.LifeSpan,
                newDog.Breed.Temperament,
                newDog.Breed.HeightAverageMetric,
                newDog.Breed.HeightAverageImperial);

            return new DomainActionResult<AddDogResult>(result);
        }
        catch (Exception ex)
        {
            return domainRepositoryResult.ReturnRepositoryError(ex);
        }
    }

    public async Task<IDomainActionResult<Dog>> GetDogByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<IDomainActionResult<AddDogResult>> GetDogsByHeightBetween(int minimumHeight, int maximumHeight)
    {
        throw new NotImplementedException();
    }

    public async Task<IDomainActionResult<AddDogResult>> GetDogsByHeightHigherThen(int minimumHeight)
    {
        throw new NotImplementedException();
    }

    public async Task<IDomainActionResult<AddDogResult>> GetDogsByHeightLowerThen(int maximumHeight)
    {
        throw new NotImplementedException();
    }
}