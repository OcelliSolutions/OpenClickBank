using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum ProductCategory
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "EBOOK")] EBOOK,
    [EnumMember(Value = "SOFTWARE")] SOFTWARE,
    [EnumMember(Value = "GAMES")] GAMES,
    [EnumMember(Value = "AUDIO")] AUDIO,
    [EnumMember(Value = "VIDEO")] VIDEO,
    [EnumMember(Value = "MEMBER_SITE")] MEMBER_SITE
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
