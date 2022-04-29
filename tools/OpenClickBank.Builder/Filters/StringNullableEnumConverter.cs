using System.Text.Json;
using System.Text.Json.Serialization;
using OpenClickBank.Builder.Extensions;

namespace OpenClickBank.Builder.Filters;

public class StringNullableEnumConverter<T> : JsonConverter<T> where T : Enum?
{
    private readonly JsonConverter<T> _converter;
    private readonly Type _underlyingType;

    public StringNullableEnumConverter() : this(null) { }

    public StringNullableEnumConverter(JsonSerializerOptions options)
    {
        // for performance, use the existing converter if available
        if (options != null) _converter = (JsonConverter<T>)options.GetConverter(typeof(T));

        // cache the underlying type
        _underlyingType = Nullable.GetUnderlyingType(typeof(T));
    }

    override public bool CanConvert(Type typeToConvert) => typeof(T).IsAssignableFrom(typeToConvert);

    override public T Read(ref Utf8JsonReader reader,
        Type typeToConvert, JsonSerializerOptions options)
    {
        if (_converter != null) return _converter.Read(ref reader, _underlyingType, options);

        var value = reader.GetString();

        if (string.IsNullOrEmpty(value)) return default;

        var result = value.GetValueFromName<T>();
        if (result == null)
        {
            throw new JsonException(
                $"Unable to convert \"{value}\" to Enum \"{_underlyingType}\".");
        }

        return result;
    }

    override public void Write(Utf8JsonWriter writer,
        T value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value?.GetDisplayName());
}