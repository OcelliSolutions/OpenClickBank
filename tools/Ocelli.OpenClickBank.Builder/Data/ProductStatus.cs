using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum ProductStatus
{
    [EnumMember(Value = "APPROVAL_REQUIRED")] APPROVAL_REQUIRED,
    [EnumMember(Value = "PENDING_APPROVAL")] PENDING_APPROVAL,
    [EnumMember(Value = "UNDER_REVIEW")] UNDER_REVIEW,
    [EnumMember(Value = "ACTION_REQUIRED")] ACTION_REQUIRED,
    [EnumMember(Value = "APPROVED")] APPROVED,
    [EnumMember(Value = "DISAPPROVED")] DISAPPROVED,
    [EnumMember(Value = "INACTIVE")] INACTIVE
}