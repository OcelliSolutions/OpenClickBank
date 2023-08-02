using System.Globalization;
using System.Net;
using System.Text.Json;
using AngleSharp.Html;
using AngleSharp.Html.Parser;
using NSwag;
using Ocelli.OpenClickBank.Scraper.Extensions;
using Ocelli.OpenClickBank.Scraper.Models;
using XmlSchemaClassGenerator;

namespace Ocelli.OpenClickBank.Scraper.Services;

internal class ScraperService
{
    private readonly List<double> _apiVersions;
    private readonly List<string> _partVersions;

    public ScraperService(List<double> apiVersions, List<string> partVersions)
    {
        _apiVersions = apiVersions;
        _partVersions = partVersions;
    }

    public async Task GetDocumentationHtml()
    {
        IDictionary<string, OpenApiDocument> documents = new Dictionary<string, OpenApiDocument>();
        var urlParts = new List<string>
        {
            "analytics#",
            "images#",
            "orders#",
            "products#",
            "quickstats#",
            "shipping#/shipnotice",
            "shipping#",
            "tickets#"
        };
        var endpointList = new List<EndpointInfo>();
        foreach (var part in urlParts)
        foreach (var apiVersion in _apiVersions)
        foreach (var partVersion in _partVersions)
        {
            var url = $"https://api.clickbank.com/rest/{apiVersion}/{part}".Replace("#", partVersion);
            try
            {
                var documentName = new Uri(url).Segments.Last();
                if (documentName == "shipnotice")
                {
                    documentName = string.Join("", new Uri(url).Segments.TakeLast(2));
                    documentName = documentName.Replace("shipnotice", "ShipNotice");
                    documentName = documentName.Replace("/", "");
                }
                var filePath = $"../../../v{apiVersion}/Docs/{documentName}.html";

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Open-ClickBank Scraper");

                var html = await client.GetStringAsync(url);
                var parser = new HtmlParser();
                var document = parser.ParseDocument(html);
                await using var writer = new StringWriter();
                document.ToHtml(writer, new PrettyMarkupFormatter());

                var file = new FileInfo(filePath);
                file.Directory?.Create();
                await File.WriteAllTextAsync(filePath, writer.ToString());
                var parsedEndpoints = DocumentExtensions.ExtractEndpoints(html);
                endpointList.AddRange(parsedEndpoints);

                var openApi = DocumentExtensions.GenerateOpenApiSpec(parsedEndpoints, $"ClickBank API: {documentName}",
                    $"v{apiVersion}", documentName);
                documents.Add(documentName, openApi);
                if (documentName.Contains("shipping", StringComparison.InvariantCultureIgnoreCase) && !documentName.Contains("shipnotice", StringComparison.InvariantCultureIgnoreCase))
                {
                    var shipNoticeDocument = documents[$"{documentName}ShipNotice"];
                    foreach (var path in shipNoticeDocument.Paths)
                    {
                        openApi.Paths.Add(path.Key, path.Value);
                    }
                }

                var controllerName = documentName.TitleCase();
                var version = $"v{apiVersion}".Replace(".", "_");
                if (!documentName.Contains("shipnotice", StringComparison.InvariantCultureIgnoreCase))
                {
                    await ControllerExtensions.CreateController(openApi, controllerName, version);
                }
                Console.WriteLine($@"{file} COMPLETE");
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound) continue;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        endpointList = endpointList.OrderBy(e => e.Endpoint).ThenBy(e => e.Method).ToList();
        var json = JsonSerializer.Serialize(endpointList, new JsonSerializerOptions
        {
            WriteIndented = true // Formatting option for indented JSON
        });

        // Write the JSON data to the file
        await File.WriteAllTextAsync(@"../../../endpoint_summary.json", json);
    }

    public async Task GetXsd()
    {
        var urlParts = new List<string>
        {
            @"analytics#/schema/AnalyticsStatus",
            @"analytics#/schema/SubscriptionDetailResult",
            @"analytics#/schema/SubscriptionDetailResultRow",
            @"analytics#/schema/SubscriptionTrendsData",
            @"analytics#/schema/AnalyticsResult",
            @"images#/schema",
            @"orders#/schema",
            @"products#/schema",
            @"quickstats#/schema",
            @"shipping#/schema",
            @"shipping#/shipnotice/schema",
            @"tickets#/partialRefundDataSchema",
            @"tickets#/schema"
        };
        foreach (var part in urlParts)
        foreach (var apiVersion in _apiVersions)
        foreach (var partVersion in _partVersions)
        {
            var url = $"https://api.clickbank.com/rest/{apiVersion}/{part}".Replace("#", partVersion);
            try
            {
                var folderPathParts = new Uri(url).Segments.Skip(3)
                    .Select(s => char.ToUpper(s[0]) + s[1..].Replace("/", string.Empty));
                folderPathParts = folderPathParts.Where(c => !c.StartsWith("Schema"));
                var filePath = $"../../../v{apiVersion}/XSDs/{string.Join("/", folderPathParts)}.xsd";
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Ocelli Open-ClickBank Scraper");

                var html = await client.GetStringAsync(url);
                var parser = new HtmlParser();
                parser.ParseDocument(html);

                //await using var writer = new StringWriter();
                //document.ToHtml(writer, new PrettyMarkupFormatter());
                var file = new FileInfo(filePath);
                file.Directory?.Create();
                await File.WriteAllTextAsync(filePath, html);

                const string outputFolder = "../../../../Ocelli.OpenClickBank.Shared";
                var generator = new Generator
                {
                    OutputFolder = outputFolder,
                    Log = s => Console.Out.WriteLine(s),
                    GenerateNullables = true,
                    SeparateClasses = true,
                    CollectionSettersMode = CollectionSettersMode.PublicWithoutConstructorInitialization,
                    EnableNullableReferenceAttributes = true,
                    UseShouldSerializePattern = true,
                    NamespacePrefix =
                        $"v{apiVersion.ToString(CultureInfo.InvariantCulture).Replace(".", "_")}.Models"
                };

                generator.Generate(new List<string> { filePath });

                Console.WriteLine($"{file} COMPLETE");
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound) continue;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}