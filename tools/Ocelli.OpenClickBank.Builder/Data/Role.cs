using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum Role
{
    [EnumMember(Value = "VENDOR")] VENDOR,
    [EnumMember(Value = "CUSTOMER")] CUSTOMER,
    [EnumMember(Value = "CBCSR")] CBCSR,
    [EnumMember(Value = "CBSYSTEM")] CBSYSTEM,
    [EnumMember(Value = "USER")] USER
}