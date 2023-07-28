using NJsonSchema;
using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Scraper.Models;

public class ParameterInfo
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("data_type")] public JsonObjectType DataType { get; set; } = JsonObjectType.String;
    [JsonPropertyName("format")] public string? Format { get; set; }
    [JsonPropertyName("default")] public object? Default { get; set; }

    [JsonPropertyName("required")] public bool? Required { get; set; }

    [JsonPropertyName("description")] public string? Description { get; set; }
}