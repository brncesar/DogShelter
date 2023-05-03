using DogShelter.Infrastructure.ApiClient.TheDogApi.Dto;

public record BreedDto(
    RangeSizeDto weight,
    RangeSizeDto height,
    int id,
    string name,
    string bred_for,
    string breed_group,
    string life_span,
    string temperament,
    string reference_image_id);