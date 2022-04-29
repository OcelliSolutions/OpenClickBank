using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using OpenClickBank;
using OpenClickBankTests.Models;
using Xunit;

namespace OpenClickBankTests.Fixtures;

public class SharedFixture : IDisposable
{
    public SharedFixture()
    {
        try
        {
            var apiKeyJson = File.ReadAllText("api_key.json");
            Debug.Assert(!string.IsNullOrWhiteSpace(apiKeyJson), "Please create a `api_key.json` file");

            var settings = JsonSerializer.Deserialize<OpenClickBankConfig>(apiKeyJson) ?? new OpenClickBankConfig();

            ApiKey = new ApiKey(settings);
            Debug.Assert(ApiKey != null, "Please specify your api key in `api_key.json` before testing");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception ex)
        {
            throw new KeyNotFoundException($@"Please create a `api_keys.json` file. {ex.Message}");
        }
    }

    public ApiKey ApiKey { get; set; } = new(new OpenClickBankConfig());

    public void Dispose() => GC.SuppressFinalize(this);
}

[CollectionDefinition("Shared collection")]
public class SharedCollection : ICollectionFixture<SharedFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
