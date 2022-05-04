using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

public class OrderList
{
    public OrderList() => OrderData = new HashSet<OrderData>();

    [JsonPropertyName("orderData")] public IEnumerable<OrderData> OrderData { get; set; }
}