using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenClickBank.Converters;

public class NullableStructConverter<T> : JsonConverter where T : struct
{
    override public bool CanWrite => false;
    override public bool CanConvert(Type objectType) => objectType == typeof(T?);

    override public object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        var underlyingType = Nullable.GetUnderlyingType(objectType);
        if (underlyingType == null)
            throw new InvalidOperationException($"Type {objectType} is not nullable");
        var token = JToken.Load(reader);
        if (token.Type == JTokenType.Null)
            return null;
        if (token.WasNilXmlElement())
            return null;
        return token.ToObject(underlyingType, serializer);
    }

    override public void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) =>
        throw new NotImplementedException();
}

public static class JTokenExtensions
{
    public static bool WasNilXmlElement(this JToken? token)
    {
        if (token == null)
            return true;
        if (token.Type == JTokenType.Null)
            return true;
        if (token is not JObject obj) return false;
        // Check if all properties were translated from XML attributes
        // and one was translated from xsi:nil = true
        // There might be namespaces present as well, e.g.
        // "@xmlns:p3": "http://www.w3.org/2001/XMLSchema-instance"
        return obj.Properties().All(p => p.Name.StartsWith("@"))
               && obj.Properties().Any(p =>
                   p.Name == "@nil" || p.Name.EndsWith(":nil") && p.Value.ToString() == "true");
    }
}