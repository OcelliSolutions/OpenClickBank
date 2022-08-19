using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum RefundType
{
    [EnumMember(Value = "FULL")] FULL,
    [EnumMember(Value = "PARTIAL_PERCENT")] PARTIAL_PERCENT,
    [EnumMember(Value = "PARTIAL_AMOUNT")] PARTIAL_AMOUNT,
    [EnumMember(Value = "PARTIAL_QUANTITY")] PARTIAL_QUANTITY,
    [EnumMember(Value = "TAX")] TAX
}