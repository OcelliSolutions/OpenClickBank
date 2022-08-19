using Ocelli.OpenClickBank.Tests.Models;
using RichardSzalay.MockHttp;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.Json;
using Xunit.Sdk;

namespace Ocelli.OpenClickBank.Tests.Fixtures;

public class SharedFixture : IDisposable
{
    public SharedFixture()
    {
        try
        {
            string apiKeyJson;
            do
            {
                try
                {
                    var fs = new FileStream(@"api_key.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    var sr = new StreamReader(fs);
                    apiKeyJson = sr.ReadToEnd();
                    sr.Close();
                    Debug.Assert(!string.IsNullOrWhiteSpace(apiKeyJson), "Please create a `api_key.json` file");
                    break;
                }
                catch (Exception)
                {
                    //There can be concurrent locks, just keep trying.
                    Thread.Sleep(new Random().Next(3, 10) * 1000);
                }
            } while (true);

            var settings = JsonSerializer.Deserialize<OpenClickBankConfig>(apiKeyJson) ?? new OpenClickBankConfig();
            var apiKeyParsed = JsonDocument.Parse(apiKeyJson);
            Receipt = apiKeyParsed.RootElement.GetProperty("receipt").ToString();

            ApiKey = new ApiKey(settings);
            Debug.Assert(ApiKey != null, "Please specify your api key in `api_key.json` before testing");

            var badRequest = new MockHttpMessageHandler();
            badRequest.When("*").Respond(HttpStatusCode.BadRequest); // Respond with JSON
            BadRequestMockHttpClient = badRequest.ToHttpClient();

            var okEmpty = new MockHttpMessageHandler();
            okEmpty.When("*").Respond(HttpStatusCode.OK, "application/json", string.Empty); // Respond with JSON
            OkEmptyMockHttpClient = okEmpty.ToHttpClient();

            var okInvalidJson = new MockHttpMessageHandler();
            okInvalidJson.When("*").Respond(HttpStatusCode.OK, "application/json", "{ 'bad-value': abc }"); // Respond with JSON
            OkInvalidJsonMockHttpClient = okInvalidJson.ToHttpClient();
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
    internal string Receipt { get; set; }
    internal HttpClient BadRequestMockHttpClient { get; set; }
    internal HttpClient OkEmptyMockHttpClient { get; set; }
    internal HttpClient OkInvalidJsonMockHttpClient { get; set; }

    public void Dispose() => GC.SuppressFinalize(this);
}

//[CollectionDefinition("Shared collection")]
public class SharedCollection : ICollectionFixture<SharedFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}

[AttributeUsage(AttributeTargets.Method)]
public class TestPriorityAttribute : Attribute
{
    public TestPriorityAttribute(int priority) => Priority = priority;
    public int Priority { get; private init; }
}

public class PriorityOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(
        IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        var assemblyName = typeof(TestPriorityAttribute).AssemblyQualifiedName!;
        var sortedMethods = new SortedDictionary<int, List<TTestCase>>();
        foreach (var testCase in testCases)
        {
            var priority = testCase.TestMethod.Method
                .GetCustomAttributes(assemblyName)
                .FirstOrDefault()
                ?.GetNamedArgument<int>(nameof(TestPriorityAttribute.Priority)) ?? 0;

            GetOrCreate(sortedMethods, priority).Add(testCase);
        }

        foreach (var testCase in
                 sortedMethods.Keys.SelectMany(
                     priority => sortedMethods[priority].OrderBy(
                         testCase => testCase.TestMethod.Method.Name)))
        {
            yield return testCase;
        }
    }

    private static TValue GetOrCreate<TKey, TValue>(
        IDictionary<TKey, TValue> dictionary, TKey key)
        where TKey : struct
        where TValue : new() =>
        dictionary.TryGetValue(key, out var result)
            ? result
            : dictionary[key] = new TValue();
}
