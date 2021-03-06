using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

public class ProductList
{
    public Products Products { get; set; } = null!;
    [JsonPropertyName("total_record_count")]
    public int TotalRecordCount { get; set; }
}