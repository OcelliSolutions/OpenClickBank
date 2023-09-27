using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class PhysicalPricing
{
    [JsonPropertyName("shipping_profile")]
    public string? ShippingProfile { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
