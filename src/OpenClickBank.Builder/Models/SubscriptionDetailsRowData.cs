namespace OpenClickBank.Builder.Models;

public class SubscriptionDetailsRowData
{
    public string? AffNickName { get; set; }
    public bool Cancelled { get; set; }
    public decimal? ChargebackAmount { get; set; }
    public int ChargebackCount { get; set; }
    public string? CountryCode { get; set; }
    public string? CurrencyCode { get; set; }
    public string? CustomerDisplayName { get; set; }
    public string? CustomerFirstName { get; set; }
    public string? CustomerLastName { get; set; }
    public int Duration { get; set; }
    public string? Email { get; set; }
    public string? Frequency { get; set; }
    public int FtxnId { get; set; }
    public int FuturePaymentsCount { get; set; }
    public decimal? InitialSaleAmount { get; set; }
    public int InitialSaleCount { get; set; }
    public string? ItemNo { get; set; }
    public DateTimeOffset? NextPaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
    public int ProcessedPaymentsCount { get; set; }
    public string? Province { get; set; }
    public string? PubNickName { get; set; }
    public DateTimeOffset? PurchaseDate { get; set; }
    public decimal? RebillSaleAmount { get; set; }
    public int RebillSaleCount { get; set; }
    public string? Receipt { get; set; }
    public decimal? RefundAmount { get; set; }
    public int RefundCount { get; set; }
    public string? Status { get; set; }
    public DateTimeOffset? SubCancelDate { get; set; }
    public DateTimeOffset? SubEndDate { get; set; }
    public decimal? SubValue { get; set; }
    public string? TimeStr { get; set; }
    public string? TrialPeriod { get; set; }
    public string? TxnType { get; set; }
}