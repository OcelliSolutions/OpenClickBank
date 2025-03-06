using System.Text.Json;

namespace Ocelli.OpenClickBank;

static internal class ModelExtensions
{
    static internal void WriteAsNullable(this Utf8JsonWriter writer, dynamic? value)
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