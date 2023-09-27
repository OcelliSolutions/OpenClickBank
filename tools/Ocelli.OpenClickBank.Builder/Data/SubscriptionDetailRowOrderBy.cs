using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum SubscriptionDetailRowOrderBy
{
    [EnumMember(Value = "RECEIPT")] RECEIPT,
    [EnumMember(Value = "PURCHASE_DATE")] PURCHASE_DATE,
    [EnumMember(Value = "SUB_END_DATE")] SUB_END_DATE,
    [EnumMember(Value = "SUB_CANCEL_DATE")] SUB_CANCEL_DATE,
    [EnumMember(Value = "NEXT_PAYMENT_DATE")] NEXT_PAYMENT_DATE,
    [EnumMember(Value = "SUB_VALUE")] SUB_VALUE,
    [EnumMember(Value = "STATUS")] STATUS,
    [EnumMember(Value = "ITEM_NUMBER")] ITEM_NUMBER,
    [EnumMember(Value = "PROCESSED_PAYMENTS_COUNT")] PROCESSED_PAYMENTS_COUNT,
    [EnumMember(Value = "FUTURE_PAYMENTS_COUNT")] FUTURE_PAYMENTS_COUNT,
    [EnumMember(Value = "REFUND_COUNT")] REFUND_COUNT,
    [EnumMember(Value = "REFUND_AMOUNT")] REFUND_AMOUNT,
    [EnumMember(Value = "CHARGEBACK_COUNT")] CHARGEBACK_COUNT,
    [EnumMember(Value = "CHARGEBACK_AMOUNT")] CHARGEBACK_AMOUNT,
    [EnumMember(Value = "PUB_NICK_NAME")] PUB_NICK_NAME,
    [EnumMember(Value = "AFFILIATE_NICK_NAME")] AFFILIATE_NICK_NAME,
    [EnumMember(Value = "CUSTOMER_FIRST_NAME")] CUSTOMER_FIRST_NAME,
    [EnumMember(Value = "CUSTOMER_LAST_NAME")] CUSTOMER_LAST_NAME,
    [EnumMember(Value = "CUSTOMER_DISPLAY_NAME")] CUSTOMER_DISPLAY_NAME,
    [EnumMember(Value = "CUSTOMER_EMAIL")] CUSTOMER_EMAIL,
    [EnumMember(Value = "DURATION")] DURATION,
    [EnumMember(Value = "INITIAL_SALE_AMOUNT")] INITIAL_SALE_AMOUNT,
    [EnumMember(Value = "INITIAL_SALE_COUNT")] INITIAL_SALE_COUNT,
    [EnumMember(Value = "REBILL_SALE_AMOUNT")] REBILL_SALE_AMOUNT,
    [EnumMember(Value = "REBILL_SALE_COUNT")] REBILL_SALE_COUNT
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
