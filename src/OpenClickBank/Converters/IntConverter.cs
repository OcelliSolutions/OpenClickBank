using System.Text.Json;
using System.Text.Json.Serialization;
using OpenClickBank.Extensions;

namespace OpenClickBank.Converters;

internal class IntConverter : JsonConverter<int?>
{
    override public int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            _ = int.TryParse(reader.GetString(), out var dbl);
            return dbl;
        }

        reader.TrySkip();
        return null;
    }

    override public void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}