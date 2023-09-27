using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum ShippingStatus
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "shipped")] SHIPPED,
    [EnumMember(Value = "notshipped")] NOT_SHIPPED,
    [EnumMember(Value = "all")] ALL
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
