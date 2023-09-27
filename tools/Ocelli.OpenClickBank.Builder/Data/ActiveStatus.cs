using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum ActiveStatus
{
    [EnumMember(Value = "ACTIVE")]
    ACTIVE,
    [EnumMember(Value = "INACTIVE")]
    INACTIVE
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
