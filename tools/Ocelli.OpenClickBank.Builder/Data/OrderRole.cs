using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum OrderRole
{
    [EnumMember(Value = "VENDOR")] VENDOR,
    [EnumMember(Value = "AFFILIATE")] AFFILIATE,
    [EnumMember(Value = "JV_TRADITIONAL")] JV_TRADITIONAL,
    [EnumMember(Value = "JV_UPSELL")] JV_UPSELL
}