using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class Price
{
    [JsonPropertyName("native_price")]
    public decimal? NativePrice { get; set; }
    public decimal? Usd { get; set; }
    [JsonPropertyName("usd_with_fees")]
    public decimal? UsdWithFees { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
