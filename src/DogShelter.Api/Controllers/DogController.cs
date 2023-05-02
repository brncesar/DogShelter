using Microsoft.AspNetCore.Mvc;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;

namespace DogShelter.Api.Controllers;

public class DogController : BaseController<DogController>
{
    private readonly AddDog _addDogUseCase;

    public DogController(
        ILogger<DogController> logger,
        AddDog addDogUseCase)
        : base(logger)
    {
        _addDogUseCase = addDogUseCase;
    }

    [HttpPost("AddDog")]
    public async Task<ActionResult> AddDog(AddDogParams addDogParams)
    {
        var domainResult = await _addDogUseCase.Execute(addDogParams);

        return DomainResult(domainResult);
    }
}