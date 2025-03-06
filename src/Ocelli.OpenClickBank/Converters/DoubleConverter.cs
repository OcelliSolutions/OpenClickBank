using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank;

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