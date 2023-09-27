using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum ContractStatus
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "PENDING_START")] PENDING_START,
    [EnumMember(Value = "PENDING_APPROVAL")] PENDING_APPROVAL,
    [EnumMember(Value = "ACTIVE")] ACTIVE,
    [EnumMember(Value = "TERMINATED")] TERMINATED,
    [EnumMember(Value = "TERMINATION_REQUESTED")] TERMINATION_REQUESTED,
    [EnumMember(Value = "EXPIRED")] EXPIRED
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
