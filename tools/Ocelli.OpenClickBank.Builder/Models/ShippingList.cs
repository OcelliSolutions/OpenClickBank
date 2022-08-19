using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

public class ShippingList
{
    public ShippingList() => OrderShipData = new HashSet<OrderShipData>();
    [JsonPropertyName("orderShipData2")]
    public IEnumerable<OrderShipData> OrderShipData { get; set; }
}
