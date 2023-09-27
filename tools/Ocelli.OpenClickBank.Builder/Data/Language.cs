using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum Language
{
    [EnumMember(Value = "DE")] DE,
    [EnumMember(Value = "EN")] EN,
    [EnumMember(Value = "ES")] ES,
    [EnumMember(Value = "FR")] FR,
    [EnumMember(Value = "IT")] IT,
    [EnumMember(Value = "PT")] PT
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
