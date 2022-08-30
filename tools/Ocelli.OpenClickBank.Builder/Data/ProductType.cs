using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum ProductType
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "STANDARD")] STANDARD,
    [EnumMember(Value = "RECURRING")] RECURRING
}