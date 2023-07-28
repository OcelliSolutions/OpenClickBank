using System.Text.RegularExpressions;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.CSharp.Models;
using NSwag.CodeGeneration.OperationNameGenerators;
using Ocelli.OpenClickBank.Scraper.Helpers;

namespace Ocelli.OpenClickBank.Scraper.Extensions;

public static class ControllerExtensions
{
    public static async Task CreateController(OpenApiDocument document, string controllerName, string version)
    {
        try
        {
            const string modelNamespace = "Ocelli.OpenClickBank.Builder.Models";
            var settings = new CSharpControllerGeneratorSettings
            {
                ClassName = controllerName,
                OperationNameGenerator = new SingleClientFromOperationIdOperationNameGenerator(),
                GenerateClientInterfaces = true,
                GenerateOptionalParameters = true,
                AdditionalNamespaceUsages = new[] { "System.Text.Json" },
                ControllerTarget = CSharpControllerTarget.AspNetCore,
                ControllerStyle = CSharpControllerStyle.Abstract,
                //AdditionalContractNamespaceUsages = new []{modelNamespace},
                ExcludedParameterNames =
                    new[]
                    {
                        "api_version"
                    }, // `api_version` is going to be hard-coded in the spec to make things easier.
                CodeGeneratorSettings = { SchemaType = SchemaType.OpenApi3 },
                CSharpGeneratorSettings =
                {
                    Namespace = modelNamespace,
                    //Namespace = "Ocelli.OpenClickBank.Builder.Delete",
                    JsonLibrary = CSharpJsonLibrary.SystemTextJson,
                    GenerateOptionalPropertiesAsNullable = true,
                    GenerateNullableReferenceTypes = true,
                    GenerateDefaultValues = true,
                    GenerateDataAnnotations = true,
                    GenerateNativeRecords = true,
                    DateType = "DateTime",
                    //HandleReferences = true,
                    PropertyNameGenerator = new CustomPropertyNameGenerator()
                }
            };

            var generator = new CSharpControllerGenerator(document, settings);
            var code = generator.GenerateFile();

            //Declare a new input parameter for POST and PUT methods.
            var keyWords = new List<string>
            {
                "Create",
                "Update",
                "Send",
                "Accept",
                "Reject",
                "Move",
                "Apply",
                "Release",
                "Reschedule",
                "Cancel",
                "Calculate",
                "Complete",
                "PerformBulk",
                "Adjust",
                "Connect",
                "Set"
            };
            foreach (var keyWord in keyWords)
                code = Regex.Replace(code, $@"Task ({keyWord}\w+)\(",
                    $@"Task $1([System.ComponentModel.DataAnnotations.Required] {modelNamespace}.$1Request request, ");

            code = code.Replace(", )", ")")
                .Replace("<br/>", "")
                .Replace("<br />", "");
            var path = $@"../../../../Ocelli.OpenClickBank.Builder/Controllers/{version}";
            CreateFoldersIfMissing(path);
            path = Path.Combine(path, $@"{controllerName}Controller.cs");
            await File.WriteAllTextAsync(path, code);
            await CreateExtendedControllerIfMissing(controllerName, version);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($@"{ex.Message} | {controllerName}");
            Console.ResetColor();
        }
    }

    private static async Task CreateExtendedControllerIfMissing(string controllerName,string version)
    {
        var template = $@"using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Models;

namespace Ocelli.OpenClickBank.Builder.Controllers.{version};

/// <inheritdoc />
[ApiController]
public class {controllerName}Controller : {controllerName}ControllerBase {{}}";

        var path = $@"../../../../Ocelli.OpenClickBank.Builder/Controllers/{version}";
        CreateFoldersIfMissing(path);
        path = Path.Combine(path, $@"{controllerName}Controller.Extended.cs");
        if (!File.Exists(path))
            await File.WriteAllTextAsync(path, template);
    }

    // Create any missing folders in a path.
    private static void CreateFoldersIfMissing(string path)
    {
        var folderExists = Directory.Exists(path);
        if (!folderExists)
            Directory.CreateDirectory(path);
    }
}