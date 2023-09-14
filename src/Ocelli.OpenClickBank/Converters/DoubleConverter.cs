using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Extensions;

namespace Ocelli.OpenClickBank.Converters;

internal class DoubleConverter : JsonConverter<double?>
{
    public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            _ = double.TryParse(reader.GetString(), out var dbl);
            return dbl;
        }

        reader.TrySkip();
        return null;
    }

    public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}