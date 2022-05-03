using System.Text.Json.Serialization;
using OpenClickBank.Builder.Data;

namespace OpenClickBank.Builder.Models;

public class ProductCategoryItem
{
    [JsonPropertyName("category")]
    public ProductCategory? Category { get; set; }
}
