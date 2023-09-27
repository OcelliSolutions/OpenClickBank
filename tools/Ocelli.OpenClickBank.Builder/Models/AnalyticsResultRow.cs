namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class AnalyticsResultRow
{
    public string? DimensionIdentifier { get; set; }
    public string? DimensionValue { get; set; }
    public string? AccountNickName { get; set; }
    public AnalyticsValue[]? Data { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
