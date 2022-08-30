using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum TicketAction
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "change")] CHANGE,
    [EnumMember(Value = "close")] CLOSE,
    [EnumMember(Value = "reopen")] REOPEN
}