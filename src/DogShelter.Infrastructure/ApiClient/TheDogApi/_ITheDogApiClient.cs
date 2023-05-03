namespace DogShelter.Infrastructure.ApiClient.TheDogApi;

public interface ITheDogApiClient
{
    Task<BreedDto> GetBreedById(int id);
}
