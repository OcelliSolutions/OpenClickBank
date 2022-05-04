using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

public class ProductCategoryItem
{
    [JsonPropertyName("category")]
    public ProductCategory? Category { get; set; }
}
