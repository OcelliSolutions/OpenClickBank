using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class AnalyticsValue
{
    public AnalyticAttribute? Attribute { get; set; }
    public AnalyticsValueDetail? Value { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
