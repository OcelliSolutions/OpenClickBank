namespace Ocelli.OpenClickBank.Builder.Models;

public class QuickStatsData
{
    public DateTimeOffset? QuickStatDate { get; set; }
    public decimal? Sale { get; set; }
    public decimal? Refund { get; set; }
    public decimal? Chargeback { get; set; }
}