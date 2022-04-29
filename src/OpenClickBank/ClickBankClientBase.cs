using System.Text.Json;
using System.Text.Json.Serialization;
using OpenClickBank.Converters;

namespace OpenClickBank;

internal class ClickBankClientBase
{
    protected static void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.Converters.Add(new BooleanConverter());
        settings.Converters.Add(new DateTimeConverter());
        settings.Converters.Add(new DateTimeOffsetConverter());
        settings.Converters.Add(new DecimalConverter());
        settings.Converters.Add(new DoubleConverter());
        settings.Converters.Add(new IntConverter());
        settings.Converters.Add(new StringConverter());
        settings.Converters.Add(new JsonStringEnumConverter());
        //settings.Converters.Add(new ArrayOrObjectJsonConverter<AccountData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<QuickStatsData>());
        //settings.Converters.Add(new SingleOrArrayConverter<AccountData>());
        //settings.Converters.Add(new SingleOrArrayConverter<QuickStatsData>());
        //settings.Converters.Add(new SingleOrArrayConverterFactory());
        //settings.Converters.Add(new StringNullableEnumConverter<RefundableState>());
        settings.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        settings.PropertyNameCaseInsensitive = true;
    }

    /*
    protected static void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
    {
        settings.Converters.Add(new NullableStructConverter<bool>());
        settings.Converters.Add(new NullableStructConverter<DateTime>());
        settings.Converters.Add(new NullableStructConverter<DateTimeOffset>());
        settings.Converters.Add(new NullableStructConverter<decimal>());
        settings.Converters.Add(new NullableStructConverter<double>());
        settings.Converters.Add(new NullableStructConverter<int>());
        //settings.Converters.Add(new NullableStructConverter<string?>());
        //settings.Converters.Add(new StringConverter());
        settings.Converters.Add(new SingleObjectOrArrayJsonConverter<QuickStatsData>());
    }
    */
}
/*
internal class StringConverter : JsonConverter<string?>
{
    override public void WriteJson(JsonWriter writer, string? value, JsonSerializer serializer) => throw new NotImplementedException();

    override public string? ReadJson(JsonReader reader, Type objectType, string? existingValue, bool hasExistingValue,
        JsonSerializer serializer) {
        if (reader.TokenType == JsonToken.String)
            return reader.ReadAsString();
        reader.Skip();
        return null;
    }
}
internal class SingleObjectOrArrayJsonConverter<T> : JsonConverter<List<T>> where T : class, new()
{
    public override void WriteJson(JsonWriter writer, List<T> value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value.Count == 1 ? (object)value.Single() : value);
    }

    public override List<T> ReadJson(JsonReader reader, Type objectType, List<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return reader.TokenType switch
        {
            JsonToken.StartObject => new List<T> { serializer.Deserialize<T>(reader) },
            JsonToken.StartArray => serializer.Deserialize<List<T>>(reader),
            _ => throw new ArgumentOutOfRangeException($"Converter does not support JSON token type {reader.TokenType}.")
        };
    }
}
*/