using AngleSharp.Html;
using AngleSharp.Html.Parser;

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
    var urls = new List<string>()
    {
        @"https://api.clickbank.com/rest/1.3/analytics",
        @"https://api.clickbank.com/rest/1.3/images",
        @"https://api.clickbank.com/rest/1.3/orders2",
        @"https://api.clickbank.com/rest/1.3/products",
        @"https://api.clickbank.com/rest/1.3/quickstats",
        @"https://api.clickbank.com/rest/1.3/shipping2",
        @"https://api.clickbank.com/rest/1.3/shipping2/shipnotice",
        @"https://api.clickbank.com/rest/1.3/tickets"
    };
    foreach (var url in urls)
    {
        try
        {
            var file = $@"../../../Docs/{new Uri(url).Segments.Last()}.html";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Open-ClickBank Scraper");

            var html = await client.GetStringAsync(url);
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            await using var writer = new StringWriter();
            document.ToHtml(writer, new PrettyMarkupFormatter());
            File.WriteAllText(file, writer.ToString());
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
            var folderPathParts = new Uri(url).Segments.Skip(3).Select(s => char.ToUpper(s[0]) + s.Substring(1).Replace("/",string.Empty));
            folderPathParts = folderPathParts.Where(c => !c.StartsWith("Schema"));
            var file = $@"../../../XSDs/{ string.Join("/", folderPathParts)}.xsd";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Open-ClickBank Scraper");

            var html = await client.GetStringAsync(url);
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            //await using var writer = new StringWriter();
            //document.ToHtml(writer, new PrettyMarkupFormatter());
            File.WriteAllText(file, html);
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