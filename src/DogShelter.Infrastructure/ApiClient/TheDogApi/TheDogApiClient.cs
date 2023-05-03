using System.Text.Json;

namespace DogShelter.Infrastructure.ApiClient.TheDogApi;

public class TheDogApiClient : ITheDogApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TheDogApiClient(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory;

    public async Task<BreedDto> GetBreedById(int id)
    {
        var httpClient = _httpClientFactory.CreateClient("TheDogApiClient");
        var response = await httpClient.GetAsync($"{id}").ConfigureAwait(false);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(response.RequestMessage.Content.ToString());

        var breed2return = JsonSerializer.Deserialize<BreedDto>(responseContent);

        return breed2return.id == 0
            ? null
            : breed2return;
    }
}
