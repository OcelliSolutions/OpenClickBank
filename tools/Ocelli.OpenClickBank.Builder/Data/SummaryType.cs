using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum SummaryType
{
    [EnumMember(Value = "VENDOR_ONLY")] VENDOR_ONLY,
    [EnumMember(Value = "AFFILIATE_ONLY")] AFFILIATE_ONLY
}