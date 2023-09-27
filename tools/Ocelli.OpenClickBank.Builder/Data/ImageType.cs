using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum ImageType
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "PRODUCT")] PRODUCT,
    [EnumMember(Value = "BANNER")] BANNER,
    [EnumMember(Value = "BANNER_CLASSIC")] BANNER_CLASSIC,
    [EnumMember(Value = "BANNER_NEW")] BANNER_NEW,
    [EnumMember(Value = "BANNER_BG")] BANNER_BG,
    [EnumMember(Value = "CUSTOM_BANNER")] CUSTOM_BANNER,
    [EnumMember(Value = "CUSTOM_BANNER_BG")] CUSTOM_BANNER_BG,
    [EnumMember(Value = "CUSTOM_ORDERFORM")] CUSTOM_ORDERFORM
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
