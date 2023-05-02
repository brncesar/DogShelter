using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Misc;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

namespace DogShelter.Infrastructure.FakeInMemory.Data;

public class BreedRepositoryMemory : IBreedRepository
{
    public static List<Breed> ListBreedMock { get; } = new List<Breed>{
        new Breed {
            ApiId = 68,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 63,
            HeightAverageImperial = 28 },
        new Breed {
            ApiId = 71,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 10,
            HeightAverageImperial = 46 },
        new Breed {
            ApiId = 33,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 15,
            HeightAverageImperial = 94 },
        new Breed {
            ApiId = 37,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 94,
            HeightAverageImperial = 20 },
        new Breed {
            ApiId = 78,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 41,
            HeightAverageImperial = 23 },
        new Breed {
            ApiId = 16,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 23,
            HeightAverageImperial = 93 },
        new Breed {
            ApiId = 53,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 66,
            HeightAverageImperial = 22 },
        new Breed {
            ApiId = 77,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 16,
            HeightAverageImperial = 4 },
        new Breed {
            ApiId = 60,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 47,
            HeightAverageImperial = 37 },
        new Breed {
            ApiId = 34,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 78,
            HeightAverageImperial = 72 },
        new Breed {
            ApiId = 60,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 48,
            HeightAverageImperial = 20 },
        new Breed {
            ApiId = 97,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 47,
            HeightAverageImperial = 15 },
        new Breed {
            ApiId = 94,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 46,
            HeightAverageImperial = 97 },
        new Breed {
            ApiId = 23,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 85,
            HeightAverageImperial = 35 },
        new Breed {
            ApiId = 56,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 48,
            HeightAverageImperial = 91 },
        new Breed {
            ApiId = 24,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 34,
            HeightAverageImperial = 87 },
        new Breed {
            ApiId = 48,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 65,
            HeightAverageImperial = 2 },
        new Breed {
            ApiId = 20,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 14,
            HeightAverageImperial = 48 },
        new Breed {
            ApiId = 68,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 15,
            HeightAverageImperial = 92 },
        new Breed {
            ApiId = 16,
            Name = "some valid domain value",
            BredFor = "some valid domain value",
            BreedGroup = "some valid domain value",
            LifeSpan = "some valid domain value",
            Temperament = "some valid domain value",
            HeightAverageMetric = 28,
            HeightAverageImperial = 41 }
        };

    public async Task<IDomainActionResult<Breed>> GetByExternalId(int id)
    {
        // If the requested ID is greater than 1000, it simulates the case where the requested breed does not exist
        Breed? breed = id > 1000
            ? null
            : new Breed
            {
                Id = new Guid("81b9f6fc-e489-11ed-b5ea-0242ac120247"),
                ApiId = 66,
                Name = "Canaan Dog",
                BreedGroup = "Herding",
                HeightAverageMetric = 55,
                HeightAverageImperial = 45,
                LifeSpan = "12 - 14 years",
                BredFor = "Guarding flocks and encampments",
                Temperament = "Cautious, Devoted, Alert, Quick, Intelligent, Vigilant",
            };

        var domainRepositoryResult = new DomainActionResult<Breed>(breed);

        return breed is not null
            ? domainRepositoryResult
            : domainRepositoryResult.AddError(AddDogErrors.BreedNotFound());
    }
}
