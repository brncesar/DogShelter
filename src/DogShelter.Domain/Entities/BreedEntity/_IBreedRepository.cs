using DogShelter.Domain.Entities.Common;

namespace DogShelter.Domain.Entities.BreedEntity;

public interface IBreedRepository {
    Task<IDomainActionResult<Breed>> GetByExternalId(int id);
}