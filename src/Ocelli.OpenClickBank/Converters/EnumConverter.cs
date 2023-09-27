using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Extensions;

namespace Ocelli.OpenClickBank.Converters;

internal class EnumConverter<T> : JsonConverter<T?> where T : Enum
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var jsonValue = reader.GetString();
            jsonValue = NormalizeJsonValue(jsonValue);
            if (jsonValue == null)
                return default;
            return (T)Enum.Parse(typeof(T), jsonValue, ignoreCase: true);
        }
        reader.TrySkip();
        return default;
    }

    public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);

    private string NormalizeJsonValue(string jsonValue)
    {
        // You can implement custom logic to normalize JSON values here.
        // For example, replace hyphens with underscores.
        return jsonValue.Replace("-", "_")
            .Replace("/", "_")
            .Replace(".", "_");
    }
}