using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum ProductStatus
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "APPROVAL_REQUIRED")] APPROVAL_REQUIRED,
    [EnumMember(Value = "PENDING_APPROVAL")] PENDING_APPROVAL,
    [EnumMember(Value = "UNDER_REVIEW")] UNDER_REVIEW,
    [EnumMember(Value = "ACTION_REQUIRED")] ACTION_REQUIRED,
    [EnumMember(Value = "APPROVED")] APPROVED,
    [EnumMember(Value = "DISAPPROVED")] DISAPPROVED,
    [EnumMember(Value = "INACTIVE")] INACTIVE
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
