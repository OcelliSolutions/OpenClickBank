using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum TicketAction
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "change")] CHANGE,
    [EnumMember(Value = "close")] CLOSE,
    [EnumMember(Value = "reopen")] REOPEN
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
