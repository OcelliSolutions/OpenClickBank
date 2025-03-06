using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank;

internal class DateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            reader.TryGetDateTime(out var dt);
            return dt;
        }

        reader.TrySkip();
        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}