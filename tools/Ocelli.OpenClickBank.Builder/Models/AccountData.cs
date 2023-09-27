using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class AccountData
{
    [JsonPropertyName("nickName")]
    public string? NickName { get; set; }
    [JsonPropertyName("quickStats")]
    public QuickStatsData[]? QuickStats { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
