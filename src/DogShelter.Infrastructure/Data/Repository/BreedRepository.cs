using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Misc;
using DogShelter.Infrastructure.Data.DbCtx;
using Microsoft.EntityFrameworkCore;
using DogShelter.Infrastructure.ApiClient.TheDogApi;
using System.Globalization;

namespace DogShelter.Infrastructure.Data.Repository;

public class BreedRepository : BaseRepository<DogShelterDbContext, Breed>, IBreedRepository
{
    private readonly ITheDogApiClient _dogApiClient;
    public BreedRepository(DogShelterDbContext dbCtx, ITheDogApiClient theDogApiClient) : base(dbCtx)
        => _dogApiClient = theDogApiClient;

    public async Task<IDomainActionResult<Breed>> GetByExternalId(int id)
    {
        var domainRepositoryResult = new DomainActionResult<Breed>();
        try
        {
            var internalSavedBreed = await _dbSet.FirstOrDefaultAsync(d => d.ApiId == id);

            if (internalSavedBreed is null) { // Must get breed from API

                var breedLoadedFromApi = await _dogApiClient.GetBreedById(id);

                if (breedLoadedFromApi is not null) {

                    var newBreed = new Breed {
                        ApiId                 = id,
                        Name                  = breedLoadedFromApi.name,
                        BredFor               = breedLoadedFromApi.bred_for,
                        LifeSpan              = breedLoadedFromApi.life_span,
                        BreedGroup            = breedLoadedFromApi.breed_group,
                        Temperament           = breedLoadedFromApi.temperament,
                        HeightAverageMetric   = GetMetricAverageValueFromRange  (breedLoadedFromApi.height.metric  ),
                        HeightAverageImperial = GetImperialAverageValueFromRange(breedLoadedFromApi.height.imperial),
                    };

                    await base.AddAsync(newBreed);

                    internalSavedBreed = newBreed;
                }
            }

            var breed = internalSavedBreed;

            return breed is not null
                ? domainRepositoryResult.SetValue(breed)
                : domainRepositoryResult.NotFound();
        }
        catch (Exception ex)
        {
            return domainRepositoryResult.ReturnRepositoryError(ex);
        }
    }

    private static int GetMetricAverageValueFromRange(string range)
    {
        if (range is null) return 0;
        var rangeNumbers = range.Trim().Split(" - ");

        if (rangeNumbers.Length == 1) return int.Parse(rangeNumbers[0]);

        var from = int.Parse(rangeNumbers[0]);
        var to   = int.Parse(rangeNumbers[1]);

        return Convert.ToInt32((from + to) / 2);
    }

    private static decimal GetImperialAverageValueFromRange(string range)
    {
        if (range is null) return 0;
        var rangeNumbers = range.Trim().Split(" - ");

        if (rangeNumbers.Length == 1) return decimal.Parse(rangeNumbers[0]);

        var from = decimal.Parse(rangeNumbers[0], CultureInfo.InvariantCulture);
        var to   = decimal.Parse(rangeNumbers[1], CultureInfo.InvariantCulture);

        return (from + to) / 2;
    }
}