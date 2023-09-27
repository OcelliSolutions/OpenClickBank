using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum OrderRoleRequest
{
    [EnumMember(Value = "VENDOR")] VENDOR,
    [EnumMember(Value = "AFFILIATE")] AFFILIATE
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
