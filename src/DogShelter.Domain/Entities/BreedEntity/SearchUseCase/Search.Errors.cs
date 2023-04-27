using DogShelter.Domain.Common;

namespace DogShelter.Domain.Entities.BreedEntity.SearchUseCase;

public sealed class SearchErrors
{
    private static string className = nameof(SearchErrors).Replace("Errors", "");

    // public static Error SomeUseCaseError() => ErrorHelpers.GetError(ErrorType.NotFound, "The related Breed was not found", codeError: $"Search.SomeUseCaseError");
}