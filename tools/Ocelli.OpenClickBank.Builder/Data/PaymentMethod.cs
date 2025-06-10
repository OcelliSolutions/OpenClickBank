using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
    [EnumMember(Value = "MSTR_PAZE")]
    MSTR_PAZE,
    [EnumMember(Value = "MSTR_APPLE")]
    MSTR_APPLE,
    [EnumMember(Value = "VISA_PAZE")]
    VISA_PAZE
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

