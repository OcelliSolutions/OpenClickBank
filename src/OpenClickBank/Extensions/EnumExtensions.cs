using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OpenClickBank.Extensions;

public static class EnumExtensions
{
    public static string? GetDisplayName(this Enum enumValue) =>
        enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();

    public static T? GetEnumFromString<T>(this string? name) where T : Enum
    {
        var type = typeof(T);

        foreach (var field in type.GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute attribute)
            {
                if (attribute.Name == name) return (T?)field.GetValue(null);
            }

            if (field.Name == name) return (T?)field.GetValue(null);
        }

        throw new ArgumentOutOfRangeException(nameof(name));
    }
}