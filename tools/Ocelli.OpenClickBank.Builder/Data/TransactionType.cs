using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum TransactionType
{
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