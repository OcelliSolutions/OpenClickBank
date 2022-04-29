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
        //settings.Converters.Add(new JsonStringEnumConverter());
        settings.Converters.Add(new EnumConverter<AnalyticAttribute>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<QuickStatsData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<TicketComments>());
        settings.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        settings.PropertyNameCaseInsensitive = true;
    }
}
