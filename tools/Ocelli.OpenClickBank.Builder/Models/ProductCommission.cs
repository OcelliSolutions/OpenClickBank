using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

public class ProductCommission
{
    public decimal? Purchase { get; set; }
    public decimal? Rebill { get; set; }
    [JsonPropertyName("no_rebill_commission")]
    public bool NoRebillCommission { get; set; }
    [JsonPropertyName("commission_tier_override")]
    public bool CommissionTierOverride { get; set; }
}