using System.Text.Json.Serialization;

namespace OpenClickBank.Builder.Models;

public class Pricing
{
    [JsonPropertyName("@currency")]
    public string Currency { get; set; } = null!;
    public StandardPricing? Standard { get; set; }
    public PhysicalPricing? Physical { get; set; }
    public RecurringPricing? Recurring { get; set; }
}