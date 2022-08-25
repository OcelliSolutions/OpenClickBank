using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

public class ShippingNoticeList
{
    public ShippingNoticeList() => ShippingNoticeData = new HashSet<ShippingNoticeData>();

    [JsonPropertyName("shippingNoticeData")] public IEnumerable<ShippingNoticeData> ShippingNoticeData { get; set; }
}
