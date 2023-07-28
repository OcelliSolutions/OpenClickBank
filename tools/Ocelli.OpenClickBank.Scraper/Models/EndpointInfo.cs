using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Scraper.Models;

public class EndpointInfo
{
    [JsonPropertyName("method")] public string Method { get; set; } = null!;
    [JsonPropertyName("operation_id")] public string? OperationId { get; set; }

    [JsonPropertyName("endpoint")] public string Endpoint { get; set; } = null!;

    [JsonPropertyName("description")] public string? Description { get; set; }

    [JsonPropertyName("parameters")] public List<ParameterInfo> Parameters { get; set; } = new();
}