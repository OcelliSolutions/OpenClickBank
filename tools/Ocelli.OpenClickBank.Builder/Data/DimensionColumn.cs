using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum DimensionColumn
{
    [EnumMember(Value = "CHARGEBACK_AMOUNT")] CHARGEBACK_AMOUNT,
    [EnumMember(Value = "CHARGEBACK_COUNT")] CHARGEBACK_COUNT,
    [EnumMember(Value = "CHARGEBACK_RATE")] CHARGEBACK_RATE,
    [EnumMember(Value = "DIMENSION_VALUE")] DIMENSION_VALUE,
    [EnumMember(Value = "EARNINGS_PER_HOP")] EARNINGS_PER_HOP,
    [EnumMember(Value = "GROSS_SALE_COUNT")] GROSS_SALE_COUNT,

    [EnumMember(Value = "GROSS_SALE_AMOUNT")] GROSS_SALE_AMOUNT,
    [EnumMember(Value = "HOP_COUNT")] HOP_COUNT,
    [EnumMember(Value = "HOPS_PER_SALE")] HOPS_PER_SALE,
    [EnumMember(Value = "HOPS_PER_ORDER_FORM_IMPRESSION")] HOPS_PER_ORDER_FORM_IMPRESSION,
    [EnumMember(Value = "NET_SALE_AMOUNT")] NET_SALE_AMOUNT,
    [EnumMember(Value = "NET_SALE_COUNT")] NET_SALE_COUNT,

    [EnumMember(Value = "ORDER_FORM_SALE_CONVERSION")] ORDER_FORM_SALE_CONVERSION,
    [EnumMember(Value = "ORDER_IMPRESSION")] ORDER_IMPRESSION,
    [EnumMember(Value = "ORDER_SUBMISSION")] ORDER_SUBMISSION,
    [EnumMember(Value = "REBILL_AMOUNT")] REBILL_AMOUNT,
    [EnumMember(Value = "REBILL_COUNT")] REBILL_COUNT,
    [EnumMember(Value = "REFUND_AMOUNT")] REFUND_AMOUNT,

    [EnumMember(Value = "REFUND_COUNT")] REFUND_COUNT,
    [EnumMember(Value = "REFUND_RATE")] REFUND_RATE,
    [EnumMember(Value = "SALE_AMOUNT")] SALE_AMOUNT,
    [EnumMember(Value = "SALE_COUNT")] SALE_COUNT,
    [EnumMember(Value = "UPSELL_AMOUNT")] UPSELL_AMOUNT,
    [EnumMember(Value = "UPSELL_COUNT")] UPSELL_COUNT,
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
