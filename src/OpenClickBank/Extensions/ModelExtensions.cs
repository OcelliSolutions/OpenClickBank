using System.Text.Json;

namespace OpenClickBank.Extensions;

internal static class ModelExtensions
{
    internal static void WriteAsNullable(this Utf8JsonWriter writer, dynamic? value)
    {
        if (value == null)
        {
            writer.WriteStartObject();
            writer.WriteString("@nil", "true");
            writer.WriteEndObject();
        }
        else
            writer.WriteStringValue(value.ToString());
    }
}