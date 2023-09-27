using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum TicketActionType
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "ASSIGNED")] ASSIGNED,
    [EnumMember(Value = "COMMENTED")] COMMENTED,
    [EnumMember(Value = "CHANGED")] CHANGED,
    [EnumMember(Value = "CLOSED")] CLOSED,
    [EnumMember(Value = "EXPIRED")] EXPIRED,
    [EnumMember(Value = "REOPENED")] REOPENED,
    [EnumMember(Value = "OPENED")] OPENED,
    [EnumMember(Value = "APPROVED")] APPROVED,
    [EnumMember(Value = "DISAPPROVED")] DISAPPROVED,
    [EnumMember(Value = "ATTACHMENT")] ATTACHMENT,
    [EnumMember(Value = "ADMIN_CHANGE")] ADMIN_CHANGE,
    [EnumMember(Value = "REFUND_ACKED")] REFUND_ACKED,
    [EnumMember(Value = "NEW_PHOTO_ID")] NEW_PHOTO_ID
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
