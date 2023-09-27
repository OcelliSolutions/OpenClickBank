using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum RevRec
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "LD")] LD,
    [EnumMember(Value = "VD")] VD,
    [EnumMember(Value = "LM")] LM,
    [EnumMember(Value = "LMA")] LMA,
    [EnumMember(Value = "LMID")] LMID,
    [EnumMember(Value = "VM")] VM,
    [EnumMember(Value = "I")] I
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
