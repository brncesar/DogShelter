namespace DogShelter.CrossCutting.ExtensionMethods;

public static class EnumerableExtensionMethdos
{
    public static bool None<TSource>(this IEnumerable<TSource> source)
    {
        return !source.Any();
    }

    public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        return !source.Any(predicate);
    }
}