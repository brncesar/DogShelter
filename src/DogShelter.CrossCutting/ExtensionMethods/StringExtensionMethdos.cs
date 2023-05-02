using System.Text.RegularExpressions;

namespace DogShelter.CrossCutting.ExtensionMethods;

public static class StringExtensionMethdos
{
    public static bool IsNotNullOrNotEmpty(this string? input)
    {
        return !string.IsNullOrEmpty(input);
    }

    public static bool IsNullOrEmpty(this string? input)
    {
        return string.IsNullOrEmpty(input);
    }

    public static int GetAverageValueFromRange(this string? input)
    {
        if (input is null) return 0;

        var pattern = @"^\d+\s-\s\d+$";

        if (!Regex.IsMatch(input, pattern)) return 0;

        var rangeNumbers = input.Split(" - ");
        var from = int.Parse(rangeNumbers[0]);
        var to = int.Parse(rangeNumbers[1]);

        return Convert.ToInt32((from + to) / 2);
    }

    public static string IfIsNullOrEmptyThen(this string? input, string newValue)
    {
        return string.IsNullOrEmpty(input)
            ? newValue
            : input;
    }
}
