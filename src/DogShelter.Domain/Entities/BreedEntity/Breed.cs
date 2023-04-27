using DogShelter.Domain.Entities.Common;

namespace DogShelter.Domain.Entities.BreedEntity;

public class Breed : BaseEntity
{
    public Guid Id { get; set; }
    public int ApiId { get; set; }
    public string Name { get; set; }
    public string BredFor { get; set; }
    public string BreedGroup { get; set; }
    public string LifeSpan { get; set; }
    public string Temperament { get; set; }
    public string Weight { get; set; }
    public string Height { get; set; }
}
