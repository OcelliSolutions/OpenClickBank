using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class OrderList
{
    public OrderList() => OrderData = new HashSet<OrderData>();

    [JsonPropertyName("orderData")] public IEnumerable<OrderData> OrderData { get; set; }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
