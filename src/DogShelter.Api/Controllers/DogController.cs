using Microsoft.AspNetCore.Mvc;
using DogShelter.Domain.Entities.DogEntity.AddDogUseCase;
using DogShelter.Domain.Entities.DogEntity.FindAvailableDogsBySizeUseCase;
using DogShelter.Domain.Entities.DogEntity.GetDogsByBreedUseCase;
using DogShelter.Domain.Entities.DogEntity.GetDogsByTemperamentUseCase;

namespace DogShelter.Api.Controllers;

public class DogController : BaseController<DogController>
{
    private readonly IAddDog _addDogUseCase;
    private readonly IGetDogsByBreed _getDogsByBreedUseCase;
    private readonly IGetDogsByTemperament _getDogsByTemperamentUseCase;
    private readonly IFindAvailableDogsBySize _findAvailableDogsBySizeUseCase;

    public DogController(ILogger<DogController> logger,
        IAddDog addDogUseCase,
        IFindAvailableDogsBySize findAvailableDogsBySizeUseCase,
        IGetDogsByBreed getDogsByBreedUseCase,
        IGetDogsByTemperament getDogsByTemperamentUseCase
    ) : base(logger)
        => (_addDogUseCase, _findAvailableDogsBySizeUseCase, _getDogsByBreedUseCase, _getDogsByTemperamentUseCase) =
           ( addDogUseCase,  findAvailableDogsBySizeUseCase,  getDogsByBreedUseCase,  getDogsByTemperamentUseCase);

    [HttpPost("AddDog")]
    public async Task<ActionResult> AddDog(AddDogParams addDogParams)
        => DomainResult(await _addDogUseCase.Execute(addDogParams));

    [HttpGet("FindAvailableDogsBySize")]
    public async Task<ActionResult> FindAvailableDogsBySize([FromQuery] FindAvailableDogsBySizeParams findAvailableDogsBySizeParams)
        => DomainResult(await _findAvailableDogsBySizeUseCase.Execute(findAvailableDogsBySizeParams));

    [HttpGet("GetDogsByBreed")]
    public async Task<ActionResult> GetDogsByBreed([FromQuery] GetDogsByBreedParams getDogsByBreedParams)
        => DomainResult(await _getDogsByBreedUseCase.Execute(getDogsByBreedParams));

    [HttpGet("GetDogsByTemperament")]
    public async Task<ActionResult> GetDogsByTemperament([FromQuery] GetDogsByTemperamentParams getDogsByTemperamentParams)
        => DomainResult(await _getDogsByTemperamentUseCase.Execute(getDogsByTemperamentParams));
}
