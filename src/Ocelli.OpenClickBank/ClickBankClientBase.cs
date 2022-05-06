using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Converters;

namespace Ocelli.OpenClickBank;

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
        
        settings.Converters.Add(new ArrayOrObjectJsonConverter<AccountData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<AnalyticsResultRow>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<AnalyticsValue>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<ContactField>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<ContractContact>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<ContractBean>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<ImageData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<VendorVariableElement>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<LineItemData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<OrderData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<OrderShipData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<OrderShipLineItemData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<Product>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<Pricings>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<ProductCategoryItem>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<QuickStatsData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<SubscriptionDetailsRowData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<SubscriptionProductRowData>());
        settings.Converters.Add(new ArrayOrObjectJsonConverter<TicketCommentData>());

        settings.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        settings.PropertyNameCaseInsensitive = true;
    }
}
