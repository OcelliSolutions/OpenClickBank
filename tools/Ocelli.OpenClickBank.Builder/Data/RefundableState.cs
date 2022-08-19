using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum RefundableState
{
    [EnumMember(Value = "REFUNDABLE")] REFUNDABLE,
    [EnumMember(Value = "SUGGESTED_REFUND_BLOCK")] SUGGESTED_REFUND_BLOCK,
    [EnumMember(Value = "UNREFUNDABLE")] UNREFUNDABLE,
    [EnumMember(Value = "ALREADY_REFUNDED")] ALREADY_REFUNDED,
    [EnumMember(Value = "TOO_OLD")] TOO_OLD,
    [EnumMember(Value = "REFUND_BLOCKED")] REFUND_BLOCKED,
    [EnumMember(Value = "HAS_OPEN_REFUND")] HAS_OPEN_REFUND,
    [EnumMember(Value = "OVER_ELV_LIMIT")] OVER_ELV_LIMIT,
    [EnumMember(Value = "PROVIDER_DISCONNECTED")] PROVIDER_DISCONNECTED
}