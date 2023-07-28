using HtmlAgilityPack;
using NJsonSchema;
using NSwag;
using Ocelli.OpenClickBank.Scraper.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Ocelli.OpenClickBank.Scraper.Extensions;

static internal class DocumentExtensions
{
    static internal List<string> DateParameterNames = new() { "restartDate", "changeDate", "nextRebillDate" , "startDate", "endDate" };
    static internal List<string> StringParameterNames = new() { "sku" };
    static internal List<string> IntParameterNames = new() { "numPeriods" };
    static internal List<string> BooleanParameterNames = new(){ "applyProratedRefund", "carryAffiliate", "approvedOnly" };
    public static List<EndpointInfo> ExtractEndpoints(string html)
    {
        var endpoints = new List<EndpointInfo>();
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        // Get all <br> elements in the document
        var brElements = doc.DocumentNode.SelectNodes("//br");

        if (brElements == null) return endpoints;
        foreach (var brElement in brElements)
        {
            // Get the <b> elements that appear before the <br> element
            var bElements = brElement.SelectNodes("preceding-sibling::b");

            if (bElements is not { Count: >= 2 }) continue; // We need at least two <b> elements (method and endpoint)
            var methodEndpoint = bElements[^2].InnerText + " " + bElements[^1].InnerText;
            var methodEndpointParts = methodEndpoint.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (methodEndpointParts.Length != 2) continue; // Ensure we have both method and endpoint
            
            var endpointInfo = new EndpointInfo { Method = methodEndpointParts[0], Endpoint = methodEndpointParts[1] };

            //Find route parameters
            const string parameterPattern = @"\{(\w+)\}";
            var matches = Regex.Matches(endpointInfo.Endpoint, parameterPattern);

            foreach (Match match in matches)
            {
                // Extract the parameter name without curly braces
                var parameterName = match.Groups[1].Value;
                var parameter = new ParameterInfo
                {
                    Name = parameterName,
                    DataType = JsonObjectType.String,
                    Required = true
                };
                endpointInfo.Parameters.Add(parameter);
            }


            // Get the description text after the <br> element
            var descriptionNode = brElement.NextSibling;
            if (descriptionNode is { Name: "#text" }) endpointInfo.Description = descriptionNode.InnerText.Trim();
            // Get the <table> elements that are cousins to the <br> element
            var tableElements = brElement.SelectNodes(".//following::table[1]");

            if (tableElements != null)
                foreach (var tableElement in tableElements)
                {
                    var parameterRows = tableElement.SelectNodes(".//tr[position() > 1]");

                    if (parameterRows == null) continue;
                    foreach (var parameterRow in parameterRows)
                    {
                        var columns = parameterRow.SelectNodes(".//td");
                        if (columns is not { Count: >= 3 }) continue;
                        var parameterName = columns[0].InnerText.Trim();
                        var parameterDescription = columns[2].InnerText.Trim();

                        var parameterType = JsonObjectType.String;
                        string? parameterFormat = null;
                        if (StringParameterNames.Contains(parameterName))
                            parameterType = JsonObjectType.String;
                        else if (BooleanParameterNames.Contains(parameterName))
                            parameterType = JsonObjectType.Boolean;
                        else if (IntParameterNames.Contains(parameterName))
                            parameterType = JsonObjectType.Integer;
                        else if (DateParameterNames.Contains(parameterName))
                        {
                            parameterType = JsonObjectType.String;
                            parameterFormat = "date";
                        }

                        var parameter = new ParameterInfo
                        {
                            Name = parameterName,
                            DataType = parameterType,
                            Format = parameterFormat,
                            Required = columns[1].InnerText.Trim()
                                .Equals("true", StringComparison.OrdinalIgnoreCase),
                            Description = parameterDescription
                        };
                        endpointInfo.Parameters.Add(parameter);
                    }

                    if (methodEndpoint.EndsWith("list"))
                    {
                        var parameter = new ParameterInfo
                        {
                            Name = "page",
                            DataType = JsonObjectType.Integer,
                            Default = 1,
                            Required = false,
                            Description = "Page Number. Results only return 100 records at a time"
                        };
                        endpointInfo.Parameters.Add(parameter);
                    }
                    //endpointInfo.Parameters = endpointInfo.Parameters.OrderBy(p => p.Name).ToList();
                }

            endpoints.Add(endpointInfo);
        }

        return endpoints;
    }

    public static OpenApiDocument GenerateOpenApiSpec(List<EndpointInfo> endpoints, string title, string version, string documentName)
    {
        var document = new OpenApiDocument
        {
            Info = new OpenApiInfo { Title = title, Version = version }, Swagger = "3.0.0"
        };
        document.Servers.Add(new OpenApiServer { Url = "https://api.clickbank.com/rest" });

        var groupedEndpoints = endpoints.GroupBy(e => new { e.Method, e.Endpoint });
        
        foreach (var group in groupedEndpoints)
        {
            var endpoint =
                group.First(); // Use the first endpoint in the group, assuming the data is the same for duplicates
            if (endpoint.Endpoint?.EndsWith("schema") ?? true) continue;

            var operation = new OpenApiOperation { Summary = endpoint.Description};

            foreach (var parameter in endpoint.Parameters)
            {
                var openApiParameter = new OpenApiParameter
                {
                    Name = parameter.Name,
                    Kind = OpenApiParameterKind.Query,
                    IsRequired = parameter.Required ?? false,
                    Description = parameter.Description,
                    Schema = new JsonSchema
                    {
                        Type = parameter.DataType, // Assuming string type, you can adjust based on actual data type
                        Format = parameter.Format, 
                        Default = parameter.Default
                    }
                };

                operation.Parameters.Add(openApiParameter);
            }
            
            operation.OperationId = Helpers.OperationIdGenerator.GenerateOperationId(endpoint, documentName);
            try
            {
                //document.Paths.Add(endpoint.Endpoint, pathItem);
                // Check if the endpoint already exists in the document.Paths dictionary
                if (document.Paths.TryGetValue(endpoint.Endpoint, out var existingPathItem))
                {
                    // The endpoint is already present, so add the new method to the existing 'pathItem'.
                    existingPathItem.Add(endpoint.Method.ToLower(), operation);
                }
                else
                {
                    // The endpoint is not yet in the document.Paths dictionary, so create a new 'pathItem'
                    var newPathItem = new OpenApiPathItem { { endpoint.Method.ToLower(), operation } };
                    document.Paths.Add(endpoint.Endpoint, newPathItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"{ex.Message}: {JsonSerializer.Serialize(new { endpoint.Method, endpoint.Endpoint })}");
            }
        }
        return document;
    }

    // convert a string to title case.
    private static IEnumerable<char> CharsToTitleCase(this string s)
    {
        var newWord = true;
        foreach (var c in s)
        {
            if (newWord)
            {
                yield return char.ToUpper(c);
                newWord = false;
            }
            else
            {
                yield return c;
            }

            if (c == ' ') newWord = true;
        }
    }

    //static string TitleCase(string input) => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input);
    public static string TitleCase(this string input) => new(input.CharsToTitleCase().ToArray());
    
}