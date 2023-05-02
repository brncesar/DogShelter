using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.DogEntity;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
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

    public async Task<IDomainActionResult<AddDogResult>> AddDogAsync(AddDogParams addDogParams)
    {
        var domainRepositoryResult = new DomainActionResult<AddDogResult>();

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

    public async Task<IDomainActionResult<Dog>> GetDogByName(string name)
    {
        var domainRepositoryResult = new DomainActionResult<Dog>();

        var dog = ListDogMock.FirstOrDefault(d => d.Name.ToLower() == name.Trim().ToLower());

        return dog is not null
            ? domainRepositoryResult.SetValue(dog)
            : domainRepositoryResult.AddNotFoundError("", "");
    }
}