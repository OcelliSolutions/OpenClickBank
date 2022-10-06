using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum TicketType
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "TECH_SUPPORT")] TECH_SUPPORT,
    [EnumMember(Value = "REFUND")] REFUND,
    [EnumMember(Value = "CANCEL")] CANCEL,
    [EnumMember(Value = "PRODUCT_CHANGE")] PRODUCT_CHANGE,
    [EnumMember(Value = "ORDER_LOOKUP")] ORDER_LOOKUP,
    [EnumMember(Value = "ESCALATED")] ESCALATED,
    [EnumMember(Value = "APPROVAL_IMAGE")] APPROVAL_IMAGE,
    [EnumMember(Value = "APPROVAL_UPSELL")] APPROVAL_UPSELL,
    [EnumMember(Value = "APPROVAL_CATEGORY_CHANGE")] APPROVAL_CATEGORY_CHANGE,
    //[Obsolete("Removed May 2022")]
    [EnumMember(Value = "APPROVAL_BLOG_POST")] APPROVAL_BLOG_POST,
    [EnumMember(Value = "APPROVAL_PRODUCT")] APPROVAL_PRODUCT,
    [EnumMember(Value = "APPROVAL_ADVANCED_UPSELL")] APPROVAL_ADVANCED_UPSELL,
    [EnumMember(Value = "APPROVAL_CSS_ORDERFORM")] APPROVAL_CSS_ORDERFORM,
    [EnumMember(Value = "APPROVAL_TEMPLATE_ORDERFORM")] APPROVAL_TEMPLATE_ORDERFORM,
    [EnumMember(Value = "APPROVAL_TEMPLATE_EXITOFFER")] APPROVAL_TEMPLATE_EXITOFFER,
    [EnumMember(Value = "APPROVAL_ORDER_BUMP_CUSTOM_TEXT")] APPROVAL_ORDER_BUMP_CUSTOM_TEXT,
    [EnumMember(Value = "APPROVAL_EXIT_OFFER")] APPROVAL_EXIT_OFFER,
    [EnumMember(Value = "APPROVAL_PHOTO_ID")] APPROVAL_PHOTO_ID,
    [EnumMember(Value = "ACCT_QUESTION_ACCOUNTS")] ACCT_QUESTION_ACCOUNTS,
    [EnumMember(Value = "ACCT_QUESTION_ACCOUNTING")] ACCT_QUESTION_ACCOUNTING,
    [EnumMember(Value = "SPAM")] SPAM,
    [EnumMember(Value = "ACCOUNT_ABUSE")] ACCOUNT_ABUSE,
    [EnumMember(Value = "SECURITY_CONCERN")] SECURITY_CONCERN
}