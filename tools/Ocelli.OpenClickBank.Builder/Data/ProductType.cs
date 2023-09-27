using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum ProductType
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "STANDARD")] STANDARD,
    [EnumMember(Value = "RECURRING")] RECURRING
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
