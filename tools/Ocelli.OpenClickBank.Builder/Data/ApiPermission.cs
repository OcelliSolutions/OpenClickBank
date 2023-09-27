using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
/// <summary>
/// Permissions/scopes used when authorizing against endpoints.
/// </summary>
public enum ApiPermission
{
    [EnumMember(Value = "api_products_client")] API_PRODUCTS_CLIENT,
    [EnumMember(Value = "ach-view")] ACH_VIEW,
    [EnumMember(Value = "apiNotification")] API_NOTIFICATION,
    [EnumMember(Value = "contact-change")] CONTACT_CHANGE,

    [EnumMember(Value = "api_notifications_client")] API_NOTIFICATIONS_CLIENT,
    [EnumMember(Value = "currencyConverter")] CURRENCY_CONVERTER,
    [EnumMember(Value = "free_trials")] FREE_TRIALS,
    [EnumMember(Value = "coupons")] COUPONS,
    [EnumMember(Value = "soft_descriptor")] SOFT_DESCRIPTOR,
    [EnumMember(Value = "productLocale")] PRODUCT_LOCALE,

    [EnumMember(Value = "vendor-partial-refund")] VENDOR_PARTIAL_REFUND,

    [EnumMember(Value = "edit-orderform-quantity")] EDIT_ORDER_FORM_QUANTITY,
    [EnumMember(Value = "countdown-timer")] COUNTDOWN_TIMER,
    [EnumMember(Value = "acct-w")] ACCT_W,
    [EnumMember(Value = "flexible_refund")] FLEXIBLE_REFUND,
    [EnumMember(Value = "ROLE_LOGGED_IN")] ROLE_LOGGED_IN,

    [EnumMember(Value = "whitelist-exclusive")] WHITELIST_EXCLUSIVE,
    [EnumMember(Value = "payment-change")] PAYMENT_CHANGE,
    [EnumMember(Value = "api_order_read")] API_ORDER_READ,
    [EnumMember(Value = "txns-r")] TXNS_R,
    [EnumMember(Value = "admin_reports")] ADMIN_REPORTS,
    [EnumMember(Value = "account-change")] ACCOUNT_CHANGE,
    [EnumMember(Value = "site-change")] SITE_CHANGE,
    [EnumMember(Value = "api_order_write")] API_ORDER_WRITE,
    [EnumMember(Value = "multi-currency")] MULTI_CURRENCY,

    [EnumMember(Value = "custom_whitelist_commission")] CUSTOM_WHITELIST_COMMISSION,
    [EnumMember(Value = "api_analytics_client")] API_ANALYTICS_CLIENT,
    [EnumMember(Value = "order_skip_confirmation_page")] ORDER_SKIP_CONFIRMATION_PAGE,
    [EnumMember(Value = "user")] USER,
    [EnumMember(Value = "HAS_DEVELOPER_KEY")] HAS_DEVELOPER_KEY,

    [EnumMember(Value = "api_subscription_modifications")] API_SUBSCRIPTION_MODIFICATIONS
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
