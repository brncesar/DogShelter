using Microsoft.AspNetCore.Mvc;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;

namespace DogShelter.Api.Controllers;

public class DogController : BaseController<DogController>
{
    private readonly AddDog _addDogUseCase;
    private readonly FindAvailableDogsBySize _findAvailableDogsBySizeUseCase;

    public DogController(ILogger<DogController> logger, AddDog addDogUseCase, FindAvailableDogsBySize findAvailableDogsBySizeUseCase) : base(logger)
        => (_addDogUseCase, _findAvailableDogsBySizeUseCase) = (addDogUseCase, findAvailableDogsBySizeUseCase);

    [HttpPost("AddDog")]
    public async Task<ActionResult> AddDog(AddDogParams addDogParams)
    {
        var domainResult = await _addDogUseCase.Execute(addDogParams);

        return DomainResult(domainResult);
    }

    [HttpGet("FindAvailableDogsBySize")]
    public async Task<ActionResult> FindAvailableDogsBySize(FindAvailableDogsBySizeParams findAvailableDogsBySizeParams)
    {
        var domainResult = await _findAvailableDogsBySizeUseCase.Execute(findAvailableDogsBySizeParams);

        return DomainResult(domainResult);
    }
}
