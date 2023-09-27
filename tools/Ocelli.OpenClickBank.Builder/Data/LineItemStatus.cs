using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum LineItemStatus
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "ACTIVE")] ACTIVE,
    [EnumMember(Value = "AUTHORIZATION_FAILURE")] AUTHORIZATION_FAILURE,
    [EnumMember(Value = "CANCELED")] CANCELED,
    [EnumMember(Value = "COMPLETED")] COMPLETED,
    [EnumMember(Value = "VALIDATION_FAILURE")] VALIDATION_FAILURE
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

