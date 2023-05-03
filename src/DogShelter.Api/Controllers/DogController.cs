using Microsoft.AspNetCore.Mvc;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;
using DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;

namespace DogShelter.Api.Controllers;

public class DogController : BaseController<DogController>
{
    private readonly AddDog _addDogUseCase;
    private readonly GetDogsByBreed _getDogsByBreedUseCase;
    private readonly FindAvailableDogsBySize _findAvailableDogsBySizeUseCase;

    public DogController(ILogger<DogController> logger, AddDog addDogUseCase, FindAvailableDogsBySize findAvailableDogsBySizeUseCase, GetDogsByBreed getDogsByBreedUseCase) : base(logger)
        => (_addDogUseCase, _findAvailableDogsBySizeUseCase, _getDogsByBreedUseCase) = (addDogUseCase, findAvailableDogsBySizeUseCase, getDogsByBreedUseCase);

    [HttpPost("AddDog")]
    public async Task<ActionResult> AddDog(AddDogParams addDogParams)
    {
        var domainResult = await _addDogUseCase.Execute(addDogParams);

        return DomainResult(domainResult);
    }

    [HttpGet("FindAvailableDogsBySize")]
    public async Task<ActionResult> FindAvailableDogsBySize([FromQuery] FindAvailableDogsBySizeParams findAvailableDogsBySizeParams)
    {
        var domainResult = await _findAvailableDogsBySizeUseCase.Execute(findAvailableDogsBySizeParams);

        return DomainResult(domainResult);
    }

    [HttpGet("GetDogsByBreed")]
    public async Task<ActionResult> GetDogsByBreed([FromQuery] GetDogsByBreedParams getDogsByBreedParams)
    {
        var domainResult = await _getDogsByBreedUseCase.Execute(getDogsByBreedParams);

        return DomainResult(domainResult);
    }
}
