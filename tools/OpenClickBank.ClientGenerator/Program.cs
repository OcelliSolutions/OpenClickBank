using NJsonSchema;
using NJsonSchema.CodeGeneration;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.OperationNameGenerators;

var document = OpenApiYamlDocument.FromFileAsync("../../../../../open-clickbank.yaml").Result;
var settings = new CSharpClientGeneratorSettings()
{
    ClassName = "{controller}Client",
    ClientBaseClass = "ClickBankClientBase",
    OperationNameGenerator = new MultipleClientsFromFirstTagAndOperationIdGenerator(),
    GenerateClientInterfaces = true,
    GenerateOptionalParameters = true,
    GenerateUpdateJsonSerializerSettingsMethod = false,
    ClientClassAccessModifier = "internal",
    AdditionalNamespaceUsages = new []{"System.Text.Json"},
    CSharpGeneratorSettings =
    {
        Namespace = "OpenClickBank",
        JsonLibrary = CSharpJsonLibrary.SystemTextJson,
        GenerateOptionalPropertiesAsNullable = true,
        GenerateNullableReferenceTypes = true,
        GenerateDefaultValues = true,
        GenerateDataAnnotations = true,
        PropertyNameGenerator = new CustomPropertyNameGenerator()
    }

};

var generator = new CSharpClientGenerator(document, settings);
var code = generator.GenerateFile();
await File.WriteAllTextAsync("../../../../../src/OpenClickBank/ClickBankClient.cs", code);

public class CustomPropertyNameGenerator : IPropertyNameGenerator
{
    /// <summary>Generates the property name.</summary>
    /// <param name="property">The property.</param>
    /// <returns>The new name.</returns>
    public virtual string Generate(JsonSchemaProperty property) =>
        ConversionUtilities.ConvertToUpperCamelCase(property.Name
                .Replace("\"", string.Empty)
                .Replace("@", string.Empty)
                .Replace("?", string.Empty)
                .Replace("$", "Dollar")
                .Replace("%", "perc")
                .Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .Replace("(", "_")
                .Replace(")", string.Empty)
                .Replace(".", "-")
                .Replace("=", "-")
                .Replace("+", "plus"), true)
            .Replace("*", "Star")
            .Replace(":", "_")
            .Replace("-", "_")
            .Replace("#", "_");
}