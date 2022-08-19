using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum ShippingStatus
{
    [EnumMember(Value = "shipped")] SHIPPED,
    [EnumMember(Value = "notshipped")] NOT_SHIPPED,
    [EnumMember(Value = "all")] ALL
}