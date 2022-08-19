using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum LineItemStatus
{
    [EnumMember(Value = "ACTIVE")] ACTIVE,
    [EnumMember(Value = "AUTHORIZATION_FAILURE")] AUTHORIZATION_FAILURE,
    [EnumMember(Value = "CANCELED")] CANCELED,
    [EnumMember(Value = "COMPLETED")] COMPLETED,
    [EnumMember(Value = "VALIDATION_FAILURE")] VALIDATION_FAILURE
}
