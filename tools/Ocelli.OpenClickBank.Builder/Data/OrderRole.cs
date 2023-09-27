using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum OrderRole
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "VENDOR")] VENDOR,
    [EnumMember(Value = "AFFILIATE")] AFFILIATE,
    [EnumMember(Value = "JV_TRADITIONAL")] JV_TRADITIONAL,
    [EnumMember(Value = "JV_UPSELL")] JV_UPSELL
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
