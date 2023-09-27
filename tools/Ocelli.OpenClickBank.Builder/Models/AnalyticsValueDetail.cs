using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class AnalyticsValueDetail
{
    [JsonPropertyName("@type")]
    public string? Type { get; set; }
    
    [SwaggerSchema("The property name is actually `$` but this causes issues for code generators and is disabled for now.")]
    [JsonPropertyName("$")]
    public string? Value { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member