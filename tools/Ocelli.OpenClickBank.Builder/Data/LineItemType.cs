using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum LineItemType
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "ORIGINAL")] ORIGINAL,
    [EnumMember(Value = "BUMP")] BUMP,
    [EnumMember(Value = "CART")] CART,
    [EnumMember(Value = "STANDARD")] STANDARD,
    [EnumMember(Value = "TOKEN")] TOKEN,
    [EnumMember(Value = "UPSELL")] UPSELL
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

