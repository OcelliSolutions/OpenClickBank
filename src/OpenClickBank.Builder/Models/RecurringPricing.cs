using System.Text.Json.Serialization;
using OpenClickBank.Builder.Data;

namespace OpenClickBank.Builder.Models;

public class RecurringPricing
{
    public Price? Price { get; set; }
    public RecurringFrequency? Frequency { get; set; }
    public int? Duration { get; set; }
    [JsonPropertyName("trial_days")]
    public int? TrialDays { get; set; }
    [JsonPropertyName("pre_rebill_override")]
    public bool PreRebillOverride { get; set; }
    [JsonPropertyName("pre_rebill_leadtime")]
    public int? PreRebillLeadTime { get; set; }
    public string? RecurringTitle { get; set; }
    public string? RecurringDescription { get; set; }
    public int FrequencyValue { get; set; }
}