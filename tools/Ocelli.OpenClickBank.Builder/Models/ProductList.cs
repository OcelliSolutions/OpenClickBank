using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ProductList
{
    public Products Products { get; set; } = null!;
    [JsonPropertyName("total_record_count")]
    public int TotalRecordCount { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
