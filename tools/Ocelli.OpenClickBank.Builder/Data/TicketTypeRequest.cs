using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum TicketTypeRequest
{
    [EnumMember(Value = "rfnd")] RFND,
    [EnumMember(Value = "cncl")] CNCL,
    [EnumMember(Value = "tech")] TECH
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
