using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.Common;

namespace DogShelter.Domain.Entities.DogEntity;

public class Dog : BaseEntity
{
    public string Name                  { get; set; } = null!;
    public Guid   BreedId               { get; set; }
    public Breed  Breed                 { get; set; } = null!;
}