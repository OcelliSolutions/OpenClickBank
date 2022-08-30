using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

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