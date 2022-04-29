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
        settings.Converters.Add(new EnumConverter<ActiveStatus>());
        settings.Converters.Add(new EnumConverter<AnalyticAttribute>());
        settings.Converters.Add(new EnumConverter<ContractStatus>());
        settings.Converters.Add(new EnumConverter<Dimension>());
        settings.Converters.Add(new EnumConverter<DimensionColumn>());
        settings.Converters.Add(new EnumConverter<ImageType>());
        settings.Converters.Add(new EnumConverter<Language>());
        settings.Converters.Add(new EnumConverter<OrderType>());
        settings.Converters.Add(new EnumConverter<ProductCategory>());
        //settings.Converters.Add(new EnumConverter<ProductStatus>());
        settings.Converters.Add(new EnumConverter<ProductType>());
        settings.Converters.Add(new EnumConverter<QueryTicketType>());
        settings.Converters.Add(new EnumConverter<RecurringFrequency>());
        settings.Converters.Add(new EnumConverter<RefundableState>());
        settings.Converters.Add(new EnumConverter<RefundType>());
        settings.Converters.Add(new EnumConverter<RevRec>());
        settings.Converters.Add(new EnumConverter<Role>());
        settings.Converters.Add(new EnumConverter<RoleAccount>());
        settings.Converters.Add(new EnumConverter<ShippingStatus>());
        settings.Converters.Add(new EnumConverter<SortDirection>());
        settings.Converters.Add(new EnumConverter<SubscriptionDetailRowOrderBy>());
        settings.Converters.Add(new EnumConverter<SubscriptionStatus>());
        settings.Converters.Add(new EnumConverter<SummaryType>());
        settings.Converters.Add(new EnumConverter<TicketAction>());
        settings.Converters.Add(new EnumConverter<TicketActionType>());
        settings.Converters.Add(new EnumConverter<TicketSource>());
        settings.Converters.Add(new EnumConverter<TicketStatus>());
        settings.Converters.Add(new EnumConverter<TicketType>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<QuickStatsData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<TicketComments>());
        settings.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        settings.PropertyNameCaseInsensitive = true;
    }
}
