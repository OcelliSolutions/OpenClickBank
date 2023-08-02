using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Xml.XPath;

namespace CustomSwaggerGen
{
    public class XmlCommentsRequestBodyFilter : IRequestBodyFilter
    {
        private readonly XPathNavigator _xmlNavigator;
        private const string SummaryTag = "summary";
        private const string ExampleTag = "example";

        public XmlCommentsRequestBodyFilter(XPathDocument xmlDoc)
        {
            _xmlNavigator = xmlDoc.CreateNavigator();
        }

        public void Apply(OpenApiRequestBody requestBody, RequestBodyFilterContext context)
        {
            var bodyParameterDescription = context.BodyParameterDescription;

            if (bodyParameterDescription == null) return;

            var propertyInfo = bodyParameterDescription.PropertyInfo();
            if (propertyInfo != null)
            {
                ApplyPropertyTags(requestBody, context, propertyInfo);
                return;
            }

            var parameterInfo = bodyParameterDescription.ParameterInfo();
            if (parameterInfo == null) return;
            ApplyParamTags(requestBody, context, parameterInfo);
            return;
        }

        private void ApplyPropertyTags(OpenApiRequestBody requestBody, RequestBodyFilterContext context,
            PropertyInfo propertyInfo)
        {
            var propertyMemberName = XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(propertyInfo);

            var summaryNode = _xmlNavigator.SelectSingleNodeRecursive(propertyMemberName, SummaryTag)?.SelectSingleNode(SummaryTag);
            if (summaryNode != null)
                requestBody.Description = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml);

            var exampleNode = _xmlNavigator.SelectSingleNodeRecursive(propertyMemberName, ExampleTag)?.SelectSingleNode(ExampleTag);
            if (exampleNode == null) return;

            foreach (var mediaType in requestBody.Content.Values)
            {
                var exampleAsJson = (mediaType.Schema?.ResolveType(context.SchemaRepository) == "string")
                    ? $"\"{exampleNode}\""
                    : exampleNode.ToString();

                mediaType.Example = OpenApiAnyFactory.CreateFromJson(exampleAsJson);
            }
        }

        private void ApplyParamTags(OpenApiRequestBody requestBody, RequestBodyFilterContext context,
            ParameterInfo parameterInfo)
        {
            if (!(parameterInfo.Member is MethodInfo methodInfo)) return;

            // If method is from a constructed generic type, look for comments from the generic type method
            var targetMethod = methodInfo.DeclaringType.IsConstructedGenericType
                ? methodInfo.GetUnderlyingGenericTypeMethod()
                : methodInfo;

            if (targetMethod == null) return;

            var methodMemberName = XmlCommentsNodeNameHelper.GetMemberNameForMethod(targetMethod);
            var paramNode =
                _xmlNavigator.SelectSingleNodeRecursive(methodMemberName, $"param[@name='{parameterInfo.Name}']")?.SelectSingleNode($"param[@name='{parameterInfo.Name}']");

            if (paramNode == null) return;
            requestBody.Description = XmlCommentsTextHelper.Humanize(paramNode.InnerXml);

            var example = paramNode.GetAttribute("example", "");
            if (string.IsNullOrEmpty(example)) return;

            foreach (var mediaType in requestBody.Content.Values)
            {
                var exampleAsJson = (mediaType.Schema?.ResolveType(context.SchemaRepository) == "string")
                    ? $"\"{example}\""
                    : example;

                mediaType.Example = OpenApiAnyFactory.CreateFromJson(exampleAsJson);
            }
        }
    }
}