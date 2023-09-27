using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum SortDirection
{
    [EnumMember(Value = "ASC")] ASC,
    [EnumMember(Value = "DESC")] DESC
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
