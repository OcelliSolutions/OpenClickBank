using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum Role
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "VENDOR")] VENDOR,
    [EnumMember(Value = "CUSTOMER")] CUSTOMER,
    [EnumMember(Value = "CBCSR")] CBCSR,
    [EnumMember(Value = "CBSYSTEM")] CBSYSTEM,
    [EnumMember(Value = "USER")] USER
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
