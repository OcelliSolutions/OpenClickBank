using System.Text.Json.Serialization;

namespace OpenClickBank.Builder.Models;

public class PhysicalPricing
{
    [JsonPropertyName("shipping_profile")]
    public string? ShippingProfile { get; set; }
}