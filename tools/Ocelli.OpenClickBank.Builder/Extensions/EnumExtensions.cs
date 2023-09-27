using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Extensions;

/// <summary>
/// The extension methods for enums
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Return the value from the [Display] attribute used on an Enum.
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    public static string? GetDisplayName(this Enum enumValue) =>
        enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<EnumMemberAttribute>()?
            .Value;

    /// <summary>
    /// Return an Enum of the specified type for a given string value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static T? GetValueFromName<T>(this string name) where T : Enum
    {
        var type = typeof(T);

        foreach (var field in type.GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute attribute)
                if (attribute.Name == name)
                    return (T?)field.GetValue(null);

            if (field.Name == name) return (T?)field.GetValue(null);
        }

        throw new ArgumentOutOfRangeException(nameof(name));
    }
}