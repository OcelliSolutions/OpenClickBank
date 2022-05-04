using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

public class AnalyticsValue
{
    public AnalyticAttribute? Attribute { get; set; }
    public AnalyticsValueDetail? Value { get; set; }
}