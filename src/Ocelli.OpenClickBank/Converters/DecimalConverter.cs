using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Extensions;

namespace Ocelli.OpenClickBank.Converters;

internal class DecimalConverter : JsonConverter<decimal?>
{
    override public decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            reader.TryGetDecimal(out var value);
            return value;
        }

        reader.TrySkip();
        return null;
    }

    override public void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}