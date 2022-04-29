using System.Text.Json.Serialization;

namespace OpenClickBank;

public class OpenClickBankConfig
{
    public OpenClickBankConfig()
    {
        DeveloperApiKey = "DEV-xx";
        ClerkApiKey = "API-xx";
        HttpTimeout = TimeSpan.FromMinutes(3);
    }

    public OpenClickBankConfig(string developerApiKey, string clerkApiKey)
    {
        DeveloperApiKey = developerApiKey;
        ClerkApiKey = clerkApiKey;
        HttpTimeout = TimeSpan.FromMinutes(3);
    }

    public OpenClickBankConfig(string developerApiKey, string clerkApiKey, TimeSpan httpTimeoutTimeSpan)
    {
        DeveloperApiKey = developerApiKey;
        ClerkApiKey = clerkApiKey;
        HttpTimeout = httpTimeoutTimeSpan;
    }

    public OpenClickBankConfig(string developerApiKey, string clerkApiKey, int httpTimeoutSeconds = 180)
    {
        DeveloperApiKey = developerApiKey;
        ClerkApiKey = clerkApiKey;
        HttpTimeout = httpTimeoutSeconds <= 0
            ? new TimeSpan(0, 0, 0, 0, Timeout.Infinite)
            : TimeSpan.FromSeconds(httpTimeoutSeconds);
    }

    [JsonPropertyName("developer_api_key")]
    public string DeveloperApiKey { get; set; }

    [JsonPropertyName("clerk_api_key")] public string ClerkApiKey { get; set; }

    [JsonPropertyName("http_timeout_seconds")]
    public TimeSpan HttpTimeout { get; set; }
}