using Microsoft.AspNetCore.Mvc;
using DogShelter.Domain.Entities.BreedEntity.SearchUseCase;

namespace DogShelter.Api.Controllers;

public class BreedController : BaseController<BreedController>
{/*
    private readonly GetBreedByCodigo _getBreedByCodigoUseCase; // it`'s just an example */
    private readonly Search _searchUseCase;

    public BreedController(
        ILogger<BreedController> logger, /*
        GetBreedByCodigo getBreedByCodigoUseCase, // it`'s just an example */
        Search searchUseCase)
        : base(logger)
    {/*
        _getBreedByCodigoUseCase = getBreedByCodigoUseCase; // it`'s just an example */
        _searchUseCase = searchUseCase;
    }/*

    [HttpGet("JUST_AN_EXAMPLE_GetByCodigo/{codigo}")]
    public async Task<ActionResult> JUST_AN_EXAMPLE_GetByCodigo(string codigo)
    {
        var domainResult = await _getBreedByCodigoUseCase.Execute(new(codigo));

        return DomainResult(domainResult);
    }*/
    // 👆 Already existing api endpoint (it`'s just an example)

    // 👇 Your new endpoint to expose use case
    [HttpPost("Search")]
    public async Task<ActionResult> Search(SearchParams searchParams)
    {
        var domainResult = await _searchUseCase.Execute(searchParams);

        return DomainResult(domainResult);
    }
}