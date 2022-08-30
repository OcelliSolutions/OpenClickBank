using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

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
