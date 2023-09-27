using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ShippingNoticeList
{
    public ShippingNoticeList() => ShippingNoticeData = new HashSet<ShippingNoticeData>();

    [JsonPropertyName("shippingNoticeData")] public IEnumerable<ShippingNoticeData> ShippingNoticeData { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
