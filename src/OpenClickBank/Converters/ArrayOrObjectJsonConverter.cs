using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenClickBank.Converters;

public class ArrayOrObjectJsonConverter<T> : JsonConverter<ICollection<T>> where T : class, new()
{
    override public ICollection<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType switch
        {
            JsonTokenType.StartArray => JsonSerializer.Deserialize<T[]>(ref reader, options),
            JsonTokenType.StartObject => JsonSerializer.Deserialize<Wrapper>(ref reader, options)?.Items,
            _ => throw new JsonException()
        };

    override public void Write(Utf8JsonWriter writer, ICollection<T> value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, (object?)value, options);

    private record Wrapper(T[] Items);
}