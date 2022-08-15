using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

public class Pricing
{
    [JsonPropertyName("@currency")]
    public Currency Currency { get; set; }
    public StandardPricing? Standard { get; set; }
    public PhysicalPricing? Physical { get; set; }
    public RecurringPricing? Recurring { get; set; }
}