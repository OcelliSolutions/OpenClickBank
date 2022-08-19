using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum SortDirection
{
    [EnumMember(Value = "ASC")] ASC,
    [EnumMember(Value = "DESC")] DESC
}