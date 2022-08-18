using System.Globalization;
using System.Net;
using AngleSharp.Html;
using AngleSharp.Html.Parser;
using XmlSchemaClassGenerator;

var apiVersions = new List<double>() { 1.3, 1.4, 2.0 };
var partVersions = new List<string>() { "", "2", "3", "4" };

Console.Title = "Open:ClickBank Scraper";
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Saving Documentation HTML");
Console.ResetColor();
await GetDocumentationHtml();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Saving XSDs");
Console.ResetColor();
await GetXsd();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Scrape Complete. Press any key to continue");
Console.ResetColor();
Console.ReadKey();

async Task GetDocumentationHtml()
{
    var urlParts = new List<string>()
    {
        "analytics#",
        "images#",
        "orders#",
        "products#",
        "quickstats#",
        "shipping#",
        "shipping#/shipnotice",
        "tickets#"
    };
    foreach (var part in urlParts)
    {
        foreach (var apiVersion in apiVersions)
        {
            foreach (var partVersion in partVersions)
            {
                var url = $@"https://api.clickbank.com/rest/{apiVersion}/{part}".Replace("#", partVersion);
                try
                {
                    var filePath = $@"../../../v{apiVersion}/Docs/{new Uri(url).Segments.Last()}.html";
                    using var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("User-Agent", "Open-ClickBank Scraper");

                    var html = await client.GetStringAsync(url);
                    var parser = new HtmlParser();
                    var document = parser.ParseDocument(html);
                    await using var writer = new StringWriter();
                    document.ToHtml(writer, new PrettyMarkupFormatter());

                    FileInfo file = new FileInfo(filePath);
                    file.Directory?.Create();
                    File.WriteAllText(filePath, writer.ToString());
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
        }
    }
}

async Task GetXsd()
{
    var urlParts = new List<string>()
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
    {
        foreach (var apiVersion in apiVersions)
        {
            foreach (var partVersion in partVersions)
            {
                var url = $@"https://api.clickbank.com/rest/{apiVersion}/{part}".Replace("#", partVersion);
                try
                {
                    var folderPathParts = new Uri(url).Segments.Skip(3)
                        .Select(s => char.ToUpper(s[0]) + s.Substring(1).Replace("/", string.Empty));
                    folderPathParts = folderPathParts.Where(c => !c.StartsWith("Schema"));
                    var filePath = $@"../../../v{apiVersion}/XSDs/{string.Join("/", folderPathParts)}.xsd";
                    using var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("User-Agent", "Ocelli Open-ClickBank Scraper");

                    var html = await client.GetStringAsync(url);
                    var parser = new HtmlParser();
                    var document = parser.ParseDocument(html);
                    //await using var writer = new StringWriter();
                    //document.ToHtml(writer, new PrettyMarkupFormatter());

                    FileInfo file = new FileInfo(filePath);
                    file.Directory?.Create();
                    File.WriteAllText(filePath, html);

                    var outputFolder = $@"../../../../Ocelli.OpenClickBank.Shared";
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
                            $@"v{apiVersion.ToString(CultureInfo.InvariantCulture).Replace(".", "_")}.Models"
                    };

                    generator.Generate(new List<string>() { filePath });

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
        }
    }
}
/*
async Task GetXsd()
{
    var urls = new List<string>()
    {
        @"https://api.clickbank.com/rest/1.3/analytics/schema/AnalyticsStatus",
        @"https://api.clickbank.com/rest/1.3/analytics/schema/SubscriptionDetailResult",
        @"https://api.clickbank.com/rest/1.3/analytics/schema/SubscriptionDetailResultRow",
        @"https://api.clickbank.com/rest/1.3/analytics/schema/SubscriptionTrendsData",
        @"https://api.clickbank.com/rest/1.3/analytics/schema/AnalyticsResult",
        @"https://api.clickbank.com/rest/1.3/images/schema",
        @"https://api.clickbank.com/rest/1.3/orders2/schema",
        @"https://api.clickbank.com/rest/1.3/products/schema",
        @"https://api.clickbank.com/rest/1.3/quickstats/schema",
        @"https://api.clickbank.com/rest/1.3/shipping2/schema",
        @"https://api.clickbank.com/rest/1.3/shipping2/shipnotice/schema",
        @"https://api.clickbank.com/rest/1.3/tickets/partialRefundDataSchema",
        @"https://api.clickbank.com/rest/1.3/tickets/schema"
    };
    
    foreach (var url in urls)
    {
        try
        {
            var folderPathParts = new Uri(url).Segments.Skip(3)
                .Select(s => char.ToUpper(s[0]) + s.Substring(1).Replace("/", string.Empty));
            folderPathParts = folderPathParts.Where(c => !c.StartsWith("Schema"));
            var file = $@"../../../XSDs/{string.Join("/", folderPathParts)}.xsd";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Ocelli Open-ClickBank Scraper");

            var html = await client.GetStringAsync(url);
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            //await using var writer = new StringWriter();
            //document.ToHtml(writer, new PrettyMarkupFormatter());
            File.WriteAllText(file, html);
            
            var outputFolder = $@"../../../../Ocelli.OpenClickBank.Shared";
            var generator = new Generator
            {
                OutputFolder = outputFolder,
                Log = s => Console.Out.WriteLine(s),
                GenerateNullables = true,
                SeparateClasses = true,
                CollectionSettersMode = CollectionSettersMode.PublicWithoutConstructorInitialization,
                EnableNullableReferenceAttributes = true,
                UseShouldSerializePattern = true, 
                NamespacePrefix = "Ocelli.OpenClickBank.Shared.Models"
            };

            generator.Generate(new List<string>(){file});

            Console.WriteLine($@"{file} COMPLETE");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }
}
*/