using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Misc;
using DogShelter.Infrastructure.Data.DbCtx;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace DogShelter.Infrastructure.Data.Repository;

public class BreedRepository : BaseRepository<DogShelterDbContext, Breed>, IBreedRepository
{
    public BreedRepository(DogShelterDbContext dbCtx) : base(dbCtx) { }

    public async Task<IDomainActionResult<Breed>> GetByExternalId(int id)
    {
        var domainRepositoryResult = new DomainActionResult<Breed>();
        try
        {
            var internalSavedBreed = await _dbSet.FirstOrDefaultAsync(d => d.ApiId == id);

            if (internalSavedBreed is null) { // Must get breed from API
                // Get breed from API
                var breedFoundedOnDogApi = true;

                if (breedFoundedOnDogApi) {
                    var heightRangeMetric   = "23 - 50";
                    var heightRangeImperial = "12 - 31";

                    var newBreed = new Breed {
                        ApiId                 = 0,
                        Name                  = "",
                        BredFor               = "",
                        BreedGroup            = "",
                        LifeSpan              = "",
                        Temperament           = "",
                        HeightAverageMetric   = GetAverageValueFromRange(heightRangeMetric  ),
                        HeightAverageImperial = GetAverageValueFromRange(heightRangeImperial),
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

    private static int GetAverageValueFromRange(string range)
    {
        if (range is null) return 0;

        var pattern = @"^\d+\s-\s\d+$";

        if (!Regex.IsMatch(range, pattern)) return 0;

        var rangeNumbers = range.Split(" - ");
        var from = int.Parse(rangeNumbers[0]);
        var to = int.Parse(rangeNumbers[1]);

        return Convert.ToInt32((from + to) / 2);
    }
}