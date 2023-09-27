using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum TicketStatus
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "OPEN")] OPEN,
    [EnumMember(Value = "REOPENED")] REOPENED,
    [EnumMember(Value = "CLOSED")] CLOSED
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
