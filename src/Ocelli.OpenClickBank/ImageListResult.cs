using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank;

//TODO: Must read the response type of 206 (Partial Return). Row counts of 100 are not reliable.
public partial class ImageListResult
{
    [JsonPropertyName("hasMoreData")] public bool HasMoreData => ImageList?.Images?.Count == 100;
}

public partial class SubscriptionTrendsData
{
    [JsonPropertyName("hasMoreData")] public bool HasMoreData => Data?.Row?.Count == 100;
}
public partial class AnalyticsResult
{
    [JsonPropertyName("hasMoreData")] public bool HasMoreData => Rows?.Row?.Count == 100 || Totals?.Total?.Count == 100;
}
public partial class OrderList
{
    [JsonPropertyName("hasMoreData")] public bool HasMoreData => OrderData?.Count == 100;
}
public partial class ProductList
{
    [JsonPropertyName("hasMoreData")] public bool HasMoreData => Products?.Product?.Count == 100;
}
public partial class ShippingList
{
    [JsonPropertyName("hasMoreData")] public bool HasMoreData => OrderShipData?.Count == 100;
}
public partial class TicketList
{
    [JsonPropertyName("hasMoreData")] public bool HasMoreData => TicketData?.Count == 100;
}