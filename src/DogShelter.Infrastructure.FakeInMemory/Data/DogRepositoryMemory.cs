using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.DogEntity;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Entities.DogEntity.Common;
using DogShelter.Domain.Misc;

namespace DogShelter.Infrastructure.FakeInMemory.Data;

public class DogRepositoryMemory : IDogRepository
{
    private readonly IBreedRepository _breedRepository;

    public static List<Dog> ListDogMock { get; } = new List<Dog>{
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(0) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(1) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(2) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(3) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(4) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(5) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(6) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(7) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(8) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(9) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(10) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(11) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(12) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(13) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(14) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(15) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(16) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(17) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(18) },
        new Dog {
                Name = "some valid domain value",
                Breed = BreedRepositoryMemory.ListBreedMock.ElementAt(19) }
    };

    public DogRepositoryMemory(IBreedRepository breedRepository)
        => _breedRepository = breedRepository;

    public async Task<IDomainActionResult<FlatDogResult>> AddDogAsync(AddDogParams addDogParams)
    {
        var domainRepositoryResult = new DomainActionResult<FlatDogResult>();

        var getBreedByIdResult = await _breedRepository.GetByExternalId(addDogParams.BreedId);

        if (getBreedByIdResult.HasErrors())
            return domainRepositoryResult.AddErrors(getBreedByIdResult.Errors);

        var newDog = new Dog
        {
            Id = Guid.NewGuid(),
            Name = addDogParams.Name,
            Breed = getBreedByIdResult.Value,
            BreedId = getBreedByIdResult.Value.Id
        };

        ListDogMock.Add(newDog);

        var result = new FlatDogResult(
            newDog.Id,
            newDog.Name,
            newDog.Breed.Name,
            newDog.Breed.BredFor,
            newDog.Breed.BreedGroup,
            newDog.Breed.LifeSpan,
            newDog.Breed.Temperament,
            newDog.Breed.HeightAverageMetric,
            newDog.Breed.HeightAverageImperial);

        return new DomainActionResult<FlatDogResult>(result);
    }

    public async Task<IDomainActionResult<Dog>> GetDogByName(string name)
    {
        var domainRepositoryResult = new DomainActionResult<Dog>();

        var dog = ListDogMock.FirstOrDefault(d => d.Name.ToLower() == name.Trim().ToLower());

        return dog is not null
            ? domainRepositoryResult.SetValue(dog)
            : domainRepositoryResult.AddNotFoundError("", "");
    }

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightBetween(bool isMeasurementSystemMetric, int minimumHeight, int maximumHeight)
        => await GetDogsByHeight(isMeasurementSystemMetric: isMeasurementSystemMetric, min: minimumHeight, max: maximumHeight);

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightHigherThen(bool isMeasurementSystemMetric, int minimumHeight)
        => await GetDogsByHeight(isMeasurementSystemMetric: isMeasurementSystemMetric, min: minimumHeight);

    public async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeightLowerThen(bool isMeasurementSystemMetric, int maximumHeight)
        => await GetDogsByHeight(isMeasurementSystemMetric: isMeasurementSystemMetric, max: maximumHeight);

    private async Task<IDomainActionResult<List<FlatDogResult>>> GetDogsByHeight(bool isMeasurementSystemMetric = true, int? min = null, int? max = null)
    {
        var domainRepositoryResult = new DomainActionResult<List<FlatDogResult>>();

        var heightLimits = new { Min = min, Max = max };

        Func<Dog, bool> filter = heightLimits switch
        {
            { Min: int _min, Max: int _max } => isMeasurementSystemMetric
                ? d => d.Breed.HeightAverageMetric   >= min && d.Breed.HeightAverageMetric   <= max
                : d => d.Breed.HeightAverageImperial >= min && d.Breed.HeightAverageImperial <= max,

            { Min: int _min, Max: null    } => isMeasurementSystemMetric
                ? d => d.Breed.HeightAverageMetric   >= min
                : d => d.Breed.HeightAverageImperial >= min,

            { Min: null, Max: int _max    } => isMeasurementSystemMetric
                ? d => d.Breed.HeightAverageMetric   <= max
                : d => d.Breed.HeightAverageImperial <= max,

            _ => throw new ArgumentException()
        };

        var foundedDogsOnRepository = ListDogMock.Where(filter);

        var foundedDogsListResult = new List<FlatDogResult>();

        foundedDogsOnRepository.ToList().ForEach(dog => foundedDogsListResult.Add(getFlatDogResultFromDogEntity(dog)));

        return domainRepositoryResult.SetValue(foundedDogsListResult);
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