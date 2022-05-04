using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Extensions;

namespace Ocelli.OpenClickBank.Converters;

internal class DateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    override public DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            reader.TryGetDateTimeOffset(out var dt);
            return dt;
        }

        reader.TrySkip();
        return null;
    }

    override public void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}