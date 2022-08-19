using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum OrderRoleRequest
{
    [EnumMember(Value = "VENDOR")] VENDOR,
    [EnumMember(Value = "AFFILIATE")] AFFILIATE
}