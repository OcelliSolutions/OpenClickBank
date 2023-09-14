using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Converters;

internal class ArrayOrObjectJsonConverter<T> : JsonConverter<ICollection<T>> where T : class, new()
{
    public override ICollection<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType switch
        {
            JsonTokenType.StartArray => JsonSerializer.Deserialize<T[]>(ref reader, options),
            JsonTokenType.StartObject => new List<T>() { JsonSerializer.Deserialize<T>(ref reader, options)! },
            _ => throw new JsonException()
        };

    public override void Write(Utf8JsonWriter writer, ICollection<T> value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, (object?)value, options);
}
