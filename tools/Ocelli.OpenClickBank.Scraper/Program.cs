using Ocelli.OpenClickBank.Scraper.Services;

var apiVersions = new List<double> { 1.3, 1.4, 2.0 };
var partVersions = new List<string> { "", "2", "3", "4" };

Console.Title = "Open:ClickBank Scraper";
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Saving Documentation HTML");
Console.ResetColor();
var scraperService = new ScraperService(apiVersions, partVersions);
await scraperService.GetDocumentationHtml();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Saving XSDs");
Console.ResetColor();
await scraperService.GetXsd();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Scrape Complete. Press any key to continue");
Console.ResetColor();
Console.ReadKey();