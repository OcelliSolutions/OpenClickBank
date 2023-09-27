using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ProductCategoryItem
{
    [JsonPropertyName("category")]
    public ProductCategory? Category { get; set; }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
