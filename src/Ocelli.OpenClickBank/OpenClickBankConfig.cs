using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank;

public class OpenClickBankConfig(string clerkApiKey, TimeSpan httpTimeoutTimeSpan)
{
    public OpenClickBankConfig() : this("API-xx", TimeSpan.FromMinutes(3))
    {
    }

    public OpenClickBankConfig(string clerkApiKey) : this(clerkApiKey, TimeSpan.FromMinutes(3))
    {
    }

    public OpenClickBankConfig(string clerkApiKey, int httpTimeoutSeconds = 180) : this(clerkApiKey, httpTimeoutSeconds <= 0
        ? new TimeSpan(0, 0, 0, 0, Timeout.Infinite)
        : TimeSpan.FromSeconds(httpTimeoutSeconds))
    {
    }

    [JsonPropertyName("clerk_api_key")] public string ClerkApiKey { get; set; } = clerkApiKey;

    [JsonPropertyName("http_timeout_seconds")]
    public TimeSpan HttpTimeout { get; set; } = httpTimeoutTimeSpan;
}