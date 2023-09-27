namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class QuickStatsData
{
    public DateTimeOffset? QuickStatDate { get; set; }
    public decimal? Sale { get; set; }
    public decimal? Refund { get; set; }
    public decimal? Chargeback { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
