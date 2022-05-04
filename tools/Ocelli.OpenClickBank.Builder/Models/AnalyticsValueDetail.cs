using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Models;

public class AnalyticsValueDetail
{
    [JsonPropertyName("@type")]
    public string? Type { get; set; }
    
    [SwaggerSchema("The property name is actually `$` but this causes issues for code generators and is disabled for now.")]
    [JsonPropertyName("$")]
    public string? Value { get; set; }
}