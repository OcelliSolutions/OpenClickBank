using NJsonSchema;
using NJsonSchema.CodeGeneration;

namespace Ocelli.OpenClickBank.Scraper.Helpers;

internal class CustomPropertyNameGenerator : IPropertyNameGenerator
{
    /// <summary>Generates the property name.</summary>
    /// <param name="property">The property.</param>
    /// <returns>The new name.</returns>
    public virtual string Generate(JsonSchemaProperty property) =>
        TitleCase(ConversionUtilities.ConvertToUpperCamelCase(property.Name
                    .Replace("\"", string.Empty)
                    .Replace("@", string.Empty)
                    .Replace("?", string.Empty)
                    .Replace("$", "Dollar")
                    .Replace("%", "perc")
                    .Replace("[", string.Empty)
                    .Replace("]", string.Empty)
                    .Replace("(", "_")
                    .Replace(")", string.Empty)
                    .Replace(".", "-")
                    .Replace("=", "-")
                    .Replace("+", "plus"), true)
                .Replace("*", "Star")
                .Replace(":", "_")
                .Replace("-", "_")
                .Replace("#", "_")
                .Replace("_", " "))
            .Replace(" ", "");


    // convert a string to title case.
    private static IEnumerable<char> CharsToTitleCase(string s)
    {
        var newWord = true;
        foreach (var c in s)
        {
            if (newWord)
            {
                yield return char.ToUpper(c);
                newWord = false;
            }
            else
            {
                yield return c;
            }

            if (c == ' ') newWord = true;
        }
    }

    //static string TitleCase(string input) => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input);
    private static string TitleCase(string input) => new(CharsToTitleCase(input).ToArray());
}