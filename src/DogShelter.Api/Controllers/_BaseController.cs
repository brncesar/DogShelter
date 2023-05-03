using DogShelter.Api.Misc;
using DogShelter.Domain.Entities.Common;
using DogShelter.Domain.Misc;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(LogEndpointFilter))]
    public abstract class BaseController<TController> : ControllerBase
    {
        public ILogger<TController> Logger { get; }

        protected BaseController(ILogger<TController> logger) => Logger = logger;

        protected ObjectResult Error<TDomainResult>(IDomainActionResult<TDomainResult> domainActionResultWithError)
        {
            HttpContext.Items[CustomProblemDetailsFactory.HttpContextApplicationErrorsKey] = domainActionResultWithError.Errors;

            var firstError = domainActionResultWithError.Errors.First();

            var title = firstError.Description;

            var qtdErros = domainActionResultWithError.Errors.Count;
            if (qtdErros > 1)
                title = $"{title} Plus more {qtdErros - 1} " +
                    $"error{(qtdErros == 2 ? "" : "s")} " +
                    $"found. " +
                    $"Look 'errorCodes' to more details.";

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict   => StatusCodes.Status409Conflict,
                ErrorType.NotFound   => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                _                    => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: title);
        }

        protected ObjectResult DomainResult<TDomainResult>(IDomainActionResult<TDomainResult> domainActionResult)
            => domainActionResult.IsSuccess()
                ? Ok(domainActionResult.Value)
                : Error(domainActionResult);
    }
}
