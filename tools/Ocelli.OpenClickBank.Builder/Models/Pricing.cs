using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class Pricing
{
    [JsonPropertyName("@currency")]
    public Currency Currency { get; set; }
    public StandardPricing? Standard { get; set; }
    public PhysicalPricing? Physical { get; set; }
    public RecurringPricing? Recurring { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
