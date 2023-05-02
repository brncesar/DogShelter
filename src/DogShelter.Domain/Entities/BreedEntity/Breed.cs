using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Entities.DogEntity;

namespace DogShelter.Domain.Entities.BreedEntity;

public class Breed : BaseEntity
{
    public int    ApiId                 { get; set; }
    public string Name                  { get; set; } = null!;
    public string BredFor               { get; set; } = null!;
    public string BreedGroup            { get; set; } = null!;
    public string LifeSpan              { get; set; } = null!;
    public string Temperament           { get; set; } = null!;
    public int    HeightAverageMetric   { get; set; }
    public int    HeightAverageImperial { get; set; }

    public List<Dog> Dogs { get; set; }
}
