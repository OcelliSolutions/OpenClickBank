using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum RecurringFrequency
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "WEEKLY")] WEEKLY,
    [EnumMember(Value = "BI_WEEKLY")] BI_WEEKLY,
    [EnumMember(Value = "MONTHLY")] MONTHLY,
    [EnumMember(Value = "QUARTERLY")] QUARTERLY,
    [EnumMember(Value = "HALF_YEARLY")] HALF_YEARLY,
    [EnumMember(Value = "YEARLY")] YEARLY,
    [EnumMember(Value = "MONTHS")] MONTHS,
    [EnumMember(Value = "WEEKS")] WEEKS,
    [EnumMember(Value = "DAYS")] DAYS
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
