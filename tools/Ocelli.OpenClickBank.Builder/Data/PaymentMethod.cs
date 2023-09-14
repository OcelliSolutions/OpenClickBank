using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum PaymentMethod
{
    [EnumMember(Value = "nil")]
    NIL,
    [EnumMember(Value = "PYPL")]
    PYPL,
    [EnumMember(Value = "PYPL-NEW")]
    PYPL_NEW,
    [EnumMember(Value = "VISA")]
    VISA,
    [EnumMember(Value = "MSTR")]
    MSTR,
    [EnumMember(Value = "DISC")]
    DISC,
    [EnumMember(Value = "AMEX")]
    AMEX,
    [EnumMember(Value = "DNRS")]
    DNRS,
    [EnumMember(Value = "MAES")]
    MAES,
    [EnumMember(Value = "TEST")]
    TEST,
    [EnumMember(Value = "N/A")]
    N_A,
}
