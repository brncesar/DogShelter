using System.ComponentModel;

namespace DogShelter.CrossCutting.ExtensionMethods;

public static class EnumExtensionMethdos
{
    public static string ToDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
        return attribute == null ? value.ToString() : attribute.Description;
    }
}