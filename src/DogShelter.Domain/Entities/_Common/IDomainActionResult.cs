﻿using DogShelter.Domain.Common;
using DogShelter.Domain.Misc;

namespace DogShelter.Domain.Entities.Common;

public interface IDomainActionResult<TResult>
{
    TResult?    Value  { get; set; }
    List<Error> Errors { get; set; }
}

public static class IDomainActionResultExtensionMethods
{
    public static bool IsSuccess<T>(this IDomainActionResult<T> domainActionResult)
        => domainActionResult.Errors.None() && !EqualityComparer<T>.Default.Equals(domainActionResult.Value, default(T));

    public static bool HasErrors<T>(this IDomainActionResult<T> domainActionResult)
        => !domainActionResult.IsSuccess();
}