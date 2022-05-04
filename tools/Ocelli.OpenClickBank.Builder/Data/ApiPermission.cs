using System.ComponentModel.DataAnnotations;

namespace Ocelli.OpenClickBank.Builder.Data;

/// <summary>
/// Permissions/scopes used when authorizing against endpoints.
/// </summary>
public enum ApiPermission
{
    [Display(Name = "api_products_client")]
    ApiProductsClient,
    [Display(Name = "ach-view")] AchView,
    [Display(Name = "apiNotification")] ApiNotification,
    [Display(Name = "contact-change")] ContactChange,

    [Display(Name = "api_notifications_client")]
    ApiNotificationsClient,
    [Display(Name = "currencyConverter")] CurrencyConverter,
    [Display(Name = "free_trials")] FreeTrials,
    [Display(Name = "coupons")] Coupons,
    [Display(Name = "soft_descriptor")] SoftDescriptor,
    [Display(Name = "productLocale")] ProductLocale,

    [Display(Name = "vendor-partial-refund")]
    VendorPartialRefund,

    [Display(Name = "edit-orderform-quantity")]
    EditOrderFormQuantity,
    [Display(Name = "countdown-timer")] CountdownTimer,
    [Display(Name = "acct-w")] AcctW,
    [Display(Name = "flexible_refund")] FlexibleRefund,
    [Display(Name = "ROLE_LOGGED_IN")] RoleLoggedIn,

    [Display(Name = "whitelist-exclusive")]
    WhitelistExclusive,
    [Display(Name = "payment-change")] PaymentChange,
    [Display(Name = "api_order_read")] ApiOrderRead,
    [Display(Name = "txns-r")] TxnsR,
    [Display(Name = "admin_reports")] AdminReports,
    [Display(Name = "account-change")] AccountChange,
    [Display(Name = "site-change")] SiteChange,
    [Display(Name = "api_order_write")] ApiOrderWrite,
    [Display(Name = "multi-currency")] MultiCurrency,

    [Display(Name = "custom_whitelist_commission")]
    CustomWhitelistCommission,

    [Display(Name = "api_analytics_client")]
    ApiAnalyticsClient,

    [Display(Name = "order_skip_confirmation_page")]
    OrderSkipConfirmationPage,
    [Display(Name = "user")] User,
    [Display(Name = "HAS_DEVELOPER_KEY")] HasDeveloperKey,

    [Display(Name = "api_subscription_modifications")]
    ApiSubscriptionModifications
}