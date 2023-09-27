using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ShippingList
{
    public ShippingList() => OrderShipData = new HashSet<OrderShipData>();
    [JsonPropertyName("orderShipData2")]
    public IEnumerable<OrderShipData> OrderShipData { get; set; }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
