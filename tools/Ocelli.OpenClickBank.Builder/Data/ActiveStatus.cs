using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum ActiveStatus
{
    [EnumMember(Value = "ACTIVE")]
    ACTIVE,
    [EnumMember(Value = "INACTIVE")]
    INACTIVE
}