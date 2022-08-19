using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum TicketTypeRequest
{
    [EnumMember(Value = "rfnd")] RFND,
    [EnumMember(Value = "cncl")] CNCL,
    [EnumMember(Value = "tech")] TECH
}