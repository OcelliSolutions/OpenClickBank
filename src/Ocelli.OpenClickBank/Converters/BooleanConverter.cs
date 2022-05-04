using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Extensions;

namespace Ocelli.OpenClickBank.Converters;

internal class BooleanConverter : JsonConverter<bool?>
{
    override public bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
            return reader.GetString() == "true";
        reader.TrySkip();
        return null;
    }

    override public void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}