using System.Text.Json.Serialization;

namespace OpenClickBank.Builder.Models;

public class OrderList
{
    public OrderList() => OrderData = new HashSet<OrderData>();

    [JsonPropertyName("orderData")] public IEnumerable<OrderData> OrderData { get; set; }
}