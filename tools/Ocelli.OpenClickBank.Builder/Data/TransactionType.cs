using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum TransactionType
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "SALE")] SALE,
    [EnumMember(Value = "RFND")] RFND,
    [EnumMember(Value = "CGBK")] CGBK,
    [EnumMember(Value = "FEE")] FEE,
    [EnumMember(Value = "BILL")] BILL,
    [EnumMember(Value = "TEST_SALE")] TEST_SALE,
    [EnumMember(Value = "TEST_BILL")] TEST_BILL,
    [EnumMember(Value = "TEST_RFND")] TEST_RFND,
    [EnumMember(Value = "TEST_FEE")] TEST_FEE
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
