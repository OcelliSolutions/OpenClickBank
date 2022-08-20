using System.Text.RegularExpressions;
using System.Web;
using NJsonSchema;
using NJsonSchema.CodeGeneration;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.OperationNameGenerators;
using Ocelli.OpenClickBank.ClientGenerator;

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
    WrapResponses = true,
    WrapResponseMethods = new []
    {
        "AnalyticsClient.GetStatisticsByRoleAndDimension",
        "AnalyticsClient.GetStatisticsByRoleAndDimensionSummary",
        "AnalyticsClient.GetSubscriptionTrends",
        "ImageClient.GetImages",
        "OrdersClient.GetOrders",
        "ProductClient.GetProducts",
        "ShippingClient.GetShipping",
        "TicketClient.GetTickets"
    }, 
    ResponseClass = "ClickBankResponse",
    CSharpGeneratorSettings =
    {
        Namespace = "Ocelli.OpenClickBank", 
        JsonLibrary = CSharpJsonLibrary.SystemTextJson,
        GenerateOptionalPropertiesAsNullable = true,
        GenerateNullableReferenceTypes = true,
        GenerateDefaultValues = true,
        GenerateDataAnnotations = true,
        PropertyNameGenerator = new CustomPropertyNameGenerator(),
        ClassStyle = CSharpClassStyle.Poco, 
        DateType = "DateOnly",
        EnumNameGenerator = new CustomEnumNameGenerator()
    }
};

var generator = new CSharpClientGenerator(document, settings);
var code = generator.GenerateFile();
code = code.Replace(
    "[System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]",
    string.Empty);

code = Regex.Replace(code, @"namespace Ocelli.OpenClickBank", $@"[assembly: System.Runtime.CompilerServices.InternalsVisibleTo(""Ocelli.OpenClickBank.Tests"")]
namespace Ocelli.OpenClickBank");

code = code.Replace("var result_ = (int)System.Convert.ChangeType(responseData_, typeof(int));",
    "int.TryParse(responseData_, out var result_);");

code = code.Replace($@"throw new ApiException(""No Content"", status_, responseText_, headers_, null);", "return null;");

code = HttpUtility.HtmlDecode(code);

await File.WriteAllTextAsync("../../../../../src/Ocelli.OpenClickBank/ClickBankClient.cs", code);

namespace Ocelli.OpenClickBank.ClientGenerator
{
    public class CustomPropertyNameGenerator : IPropertyNameGenerator
    {
        /// <summary>Generates the property name.</summary>
        /// <param name="property">The property.</param>
        /// <returns>The new name.</returns>
        public virtual string Generate(JsonSchemaProperty property)
        {
            var name = ConversionUtilities.ConvertToUpperCamelCase(property.Name
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

            if (name.StartsWith("Address", StringComparison.InvariantCultureIgnoreCase))
                return name;
            name = Regex.Replace(name, "[0-9]", "");
            return name;
        }
    }

    public class CustomEnumNameGenerator : IEnumNameGenerator
    {
        public string Generate(int index, string name, object value, JsonSchema schema) =>
            name
                .Replace(".", "_")
                .Replace("-", "_").ToUpper();
    }
}
