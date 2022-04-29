using System.Text.Json.Serialization;

namespace OpenClickBank.Builder.Models;

public class AccountData
{
    [JsonPropertyName("nickName")]
    public string? NickName { get; set; }
    [JsonPropertyName("quickStats")]
    public QuickStatsData[]? QuickStats { get; set; }
}