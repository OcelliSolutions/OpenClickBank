using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Extensions;

namespace Ocelli.OpenClickBank.Converters;

internal class StringConverter : JsonConverter<string?>
{
    override public string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
            return reader.GetString();
        reader.TrySkip();
        return null;
    }

    override public void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}