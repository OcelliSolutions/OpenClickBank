using Microsoft.Extensions.DependencyInjection;
using Ocelli.OpenClickBank.Tests.Models;
using RichardSzalay.MockHttp;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.Json;

namespace Ocelli.OpenClickBank.Tests.Fixtures;

public class SharedFixture : IDisposable
{
    public ApiKey ApiKey { get; private set; }
    internal string Receipt { get; private set; } = string.Empty;
    internal HttpClient BadRequestMockHttpClient { get; private set; }
    internal HttpClient OkEmptyMockHttpClient { get; private set; }
    internal HttpClient OkInvalidJsonMockHttpClient { get; private set; }

    private readonly IClickBankServiceFactory _clickBankServiceFactory;

    public SharedFixture()
    {
        try
        {
            // Setup dependency injection for the test factory
            var services = new ServiceCollection();
            services.AddHttpClient("ClickBankClient");
            services.AddSingleton<IClickBankServiceFactory, ClickBankServiceFactory>();

            var serviceProvider = services.BuildServiceProvider();
            _clickBankServiceFactory = serviceProvider.GetRequiredService<IClickBankServiceFactory>();

            string apiKeyJson;
            do
            {
                try
                {
                    using var fs = new FileStream(@"api_key.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using var sr = new StreamReader(fs);
                    apiKeyJson = sr.ReadToEnd();
                    Debug.Assert(!string.IsNullOrWhiteSpace(apiKeyJson), "Please create an `api_key.json` file");
                    break;
                }
                catch (Exception)
                {
                    // There can be concurrent locks, just keep trying.
                    Thread.Sleep(new Random().Next(3, 10) * 1000);
                }
            } while (true);

            var settings = JsonSerializer.Deserialize<OpenClickBankConfig>(apiKeyJson) ?? new OpenClickBankConfig();
            var apiKeyParsed = JsonDocument.Parse(apiKeyJson);
            Receipt = apiKeyParsed.RootElement.GetProperty("receipt").ToString();

            // Use factory to create ApiKey with ClickBankService
            ApiKey = new ApiKey(_clickBankServiceFactory, settings);
            Debug.Assert(ApiKey != null, "Please specify your API key in `api_key.json` before testing");

            var badRequest = new MockHttpMessageHandler();
            badRequest.When("*").Respond(HttpStatusCode.BadRequest);
            BadRequestMockHttpClient = badRequest.ToHttpClient();

            var okEmpty = new MockHttpMessageHandler();
            okEmpty.When("*").Respond(HttpStatusCode.OK, "application/json", string.Empty);
            OkEmptyMockHttpClient = okEmpty.ToHttpClient();

            var okInvalidJson = new MockHttpMessageHandler();
            okInvalidJson.When("*").Respond(HttpStatusCode.OK, "application/json", "{ \"bad-value\": \"abc\" }");
            OkInvalidJsonMockHttpClient = okInvalidJson.ToHttpClient();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception ex)
        {
            throw new KeyNotFoundException($"Please create an `api_key.json` file. {ex.Message}");
        }
    }

    public void Dispose() => GC.SuppressFinalize(this);
}

//[CollectionDefinition("Shared collection")]
public class SharedCollection : ICollectionFixture<SharedFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
