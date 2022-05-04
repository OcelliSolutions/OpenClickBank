namespace Ocelli.OpenClickBank.Builder.Data;

public enum RefundableState
{
    nil,
    REFUNDABLE,
    SUGGESTED_REFUND_BLOCK,
    UNREFUNDABLE,
    ALREADY_REFUNDED,
    TOO_OLD,
    REFUND_BLOCKED,
    HAS_OPEN_REFUND,
    OVER_ELV_LIMIT,
    PROVIDER_DISCONNECTED
}