namespace Ocelli.OpenClickBank.Builder.Models;

public class AnalyticsResultRow
{
    public string? DimensionIdentifier { get; set; }
    public string? DimensionValue { get; set; }
    public string? AccountNickName { get; set; }
    public AnalyticsValue[]? Data { get; set; }
}