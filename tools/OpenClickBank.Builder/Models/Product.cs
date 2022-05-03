using System.Text.Json.Serialization;
using OpenClickBank.Builder.Data;

namespace OpenClickBank.Builder.Models;

public class Product
{
    [JsonPropertyName("@sku")]
    public string Sku { get; set; } = null!;

    public int? Id { get; set; }
    public ActiveStatus? Status { get; set; }
    public bool Digital { get; set; }
    public bool Physical { get; set; }
    public bool DigitalRecurring { get; set; }
    public bool PhysicalRecurring { get; set; }
    public string? Site { get; set; }
    public string? Created { get; set; }
    public string? Updated { get; set; }
    [JsonPropertyName("approval_status")]
    public ProductApprovalStatus? ApprovalStatus { get; set; }
    public string? Language { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    [JsonPropertyName("post_purchase_description")]
    public string? PostPurchaseDescription { get; set; }
    public ImageBean? Image { get; set; }
    [JsonPropertyName("thank_you_pages")]
    public ThankYouPages? ThankYouPages { get; set; }
    [JsonPropertyName("pitch_pages")]
    public PitchPages? PitchPages { get; set; }
    public ProductCommission? Commission { get; set; }
    public Pricings? Pricings { get; set; }
    public ContractBean[]? Contracts { get; set; }
    public ProductCategoryItem[]? Categories { get; set; }
    [JsonPropertyName("disable_geo_currency")]
    public bool? DisableGeoCurrency { get; set; }
    [JsonPropertyName("allow_currency_change")]
    public bool? AllowCurrencyChange { get; set; }
    [JsonPropertyName("us_tax_exempt")]
    public bool? UsTaxExempt { get; set; }
    [JsonPropertyName("revenue_recognition")]
    public RevRec? RevenueRecognition { get; set; }
    [JsonPropertyName("reduced_upsell_markup")]
    public bool? ReducedUpsellMarkup { get; set; }
    [JsonPropertyName("skip_confirmation_page")]
    public bool? SkipConfirmationPage { get; set; }
    [JsonPropertyName("admin_download_url")]
    public string? AdminDownloadUrl { get; set; }
    [JsonPropertyName("admin_mobile_download_url")]
    public string? AdminMobileDownloadUrl { get; set; }
    [JsonPropertyName("no_commission")]
    public bool NoCommission { get; set; }
    [JsonPropertyName("sale_refund_days_limit")]
    public int? SaleRefundDaysLimit { get; set; }
    [JsonPropertyName("rebill_refund_days_limit")]
    public int? RebillRefundDaysLimit { get; set; }
    [JsonPropertyName("admin_restrict_flexible_refund")]
    public bool? AdminRestrictFlexibleRefund { get; set; }
    [JsonPropertyName("commission_tier_override")]
    public bool CommissionTierOverride { get; set; }
    public string? DeliveryMethod { get; set; }
    public string? DeliverySpeed { get; set; }
    public int? IsPartOfOrderBump { get; set; }
    public bool IsInitialOfOrderBump { get; set; }
    public bool IsProductOfOrderBump { get; set; }
    public bool? PhoneNumberOnOrderForm { get; set; }
    public bool? DelayedDelivery { get; set; }
    public bool? SendRebillNotification { get; set; }
    //todo: go through all models and if the object is minOccurs="0", set it to be nullable. ClickBank will just not send it sometimes.
    //todo: ensure that all properties that are "unbounded" are set to arrays. They may be sent as arrays or objects.
}