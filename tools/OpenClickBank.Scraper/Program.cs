using AngleSharp.Html;
using AngleSharp.Html.Parser;

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
Directory.CreateDirectory("spec");
foreach (var url in urls)
{
    var file = $@"spec/{new Uri(url).Segments.Last()}.html";
    using var client = new HttpClient();
    client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

    var html = await client.GetStringAsync(url);
    var parser = new HtmlParser();
    var document = parser.ParseDocument(html);
    await using var writer = new StringWriter();
    document.ToHtml(writer, new PrettyMarkupFormatter());
    File.WriteAllText(file, writer.ToString());
    Console.WriteLine($@"{file} COMPLETE");
}

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Scrape Complete. Copy the HTML files from the bin/spec directory to the solution folder.");
Console.ResetColor();
