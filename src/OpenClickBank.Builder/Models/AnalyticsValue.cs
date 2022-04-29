using OpenClickBank.Builder.Data;

namespace OpenClickBank.Builder.Models;

public class AnalyticsValue
{
    public AnalyticAttribute? Attribute { get; set; }
    public AnalyticsValueDetail? Value { get; set; }
}