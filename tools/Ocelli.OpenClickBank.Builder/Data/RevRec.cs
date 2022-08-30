using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

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