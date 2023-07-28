using Ocelli.OpenClickBank.Scraper.Models;
using PluralizeService.Core;

namespace Ocelli.OpenClickBank.Scraper.Helpers;
public static class OperationIdGenerator
{
    // Reserved C# keywords, you can add more if needed
    private readonly static HashSet<string> ReservedKeywords = new()
    {
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
        "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
        "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
        "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is",
        "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override",
        "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte",
        "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch",
        "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe",
        "ushort", "using", "virtual", "void", "volatile", "while"
    };

    public static string GenerateOperationId(EndpointInfo endpointInfo, string rootApiName)
    {
        // Step 1: Normalize the API path
        var lastPart = GetLastNonParameterRoutePart(endpointInfo.Endpoint);

        // Step 2: Ensure uniqueness
        var uniqueOperationId = EnsureUniqueOperationId(lastPart);

        // Step 3: Handle reserved keywords
        var safeOperationId = HandleReservedKeywords(uniqueOperationId);
        if (safeOperationId == rootApiName)
        {
            safeOperationId = new string(safeOperationId.Where(c => !char.IsDigit(c)).ToArray());

            safeOperationId = PluralizationProvider.Singularize(safeOperationId);
            var singularRootApiName = PluralizationProvider.Singularize(rootApiName);
            var prefix = endpointInfo.Method switch
            {
                "GET" => "Get",
                "PUT" => "Update",
                "POST" => "Create",
                "DELETE" => "Delete",
                "HEAD" => "Get",
                _ => string.Empty
            };
            var suffix = endpointInfo.Method switch
            {
                "HEAD" => "Status",
                _ => string.Empty
            };
            safeOperationId = UppercaseFirstLetter(safeOperationId);
            safeOperationId = $"{prefix}{safeOperationId}{suffix}";
        }

        // Step 5: Uppercase the first letter of the operationId
        return safeOperationId;
    }
    private static string UppercaseFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpperInvariant(input[0]) + input[1..];
    }
    private static string GetLastNonParameterRoutePart(string apiPath)
    {
        var parts = apiPath.Split('/');
        for (int i = parts.Length - 1; i >= 0; i--)
        {
            var part = parts[i];
            if (!part.StartsWith("{") || !part.EndsWith("}"))
            {
                // Return the first part that is not a route parameter
                return part;
            }
        }
        return string.Empty; // If no non-parameter part is found, return an empty string
    }

    private static string NormalizeApiPath(string apiPath)
    {
        // Remove any special characters and replace slashes with underscores
        // For simplicity, you can use a regular expression to remove non-alphanumeric characters
        string normalizedPath = new string(apiPath.Where(c => char.IsLetterOrDigit(c) || c == '/').ToArray());

        // Convert to camelCase
        normalizedPath = ToCamelCase(normalizedPath);

        return normalizedPath;
    }

    private static string ToCamelCase(string input)
    {
        // Assuming the input is already in "PascalCase" (e.g., MyApiPath), 
        // convert it to "camelCase" (e.g., myApiPath).
        if (string.IsNullOrEmpty(input) || char.IsLower(input[0]))
            return input;

        return char.ToLowerInvariant(input[0]) + input.Substring(1);
    }

    private static string EnsureUniqueOperationId(string operationId)
    {
        // You need to implement a mechanism to check if the generated OperationId is unique
        // among other operationIds in your API. For example, you can keep a list of all 
        // existing operationIds and append a number to the generated one until it becomes unique.

        // For simplicity, let's assume the operationId is already unique.
        return operationId;
    }

    private static string HandleReservedKeywords(string operationId)
    {
        // If the generated operationId is a reserved keyword, append an underscore at the end.
        if (ReservedKeywords.Contains(operationId.ToLowerInvariant()))
            return operationId + "_";

        return operationId;
    }
}

