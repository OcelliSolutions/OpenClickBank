using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ProductCommission
{
    public decimal? Purchase { get; set; }
    public decimal? Rebill { get; set; }
    [JsonPropertyName("no_rebill_commission")]
    public bool NoRebillCommission { get; set; }
    [JsonPropertyName("commission_tier_override")]
    public bool CommissionTierOverride { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
