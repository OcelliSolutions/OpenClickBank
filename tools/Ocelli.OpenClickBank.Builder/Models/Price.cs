using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

public class Price
{
    [JsonPropertyName("native_price")]
    public decimal? NativePrice { get; set; }
    public decimal? Usd { get; set; }
    [JsonPropertyName("usd_with_fees")]
    public decimal? UsdWithFees { get; set; }
}