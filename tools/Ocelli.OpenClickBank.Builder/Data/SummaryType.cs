using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum SummaryType
{
    [EnumMember(Value = "VENDOR_ONLY")] VENDOR_ONLY,
    [EnumMember(Value = "AFFILIATE_ONLY")] AFFILIATE_ONLY
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
