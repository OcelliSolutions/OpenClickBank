using System;
using System.Xml.XPath;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CustomSwaggerGen
{
    public class XmlCommentsSchemaFilter : ISchemaFilter
    {
        private readonly XPathNavigator _xmlNavigator;
        private const string SummaryTag = "summary";
        private const string ExampleTag = "example";

        public XmlCommentsSchemaFilter(XPathDocument xmlDoc)
        {
            _xmlNavigator = xmlDoc.CreateNavigator();
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            ApplyTypeTags(schema, context.Type);

            if (context.MemberInfo != null)
            {
                ApplyMemberTags(schema, context);
            }
        }

        private void ApplyTypeTags(OpenApiSchema schema, Type type)
        {
            var typeMemberName = XmlCommentsNodeNameHelper.GetMemberNameForType(type);
            var typeSummaryNode = _xmlNavigator.SelectSingleNodeRecursive(typeMemberName, SummaryTag)?.SelectSingleNode(SummaryTag);

            if (typeSummaryNode == null) return;
            schema.Description = XmlCommentsTextHelper.Humanize(typeSummaryNode.InnerXml);
        }

        private void ApplyMemberTags(OpenApiSchema schema, SchemaFilterContext context)
        {
            var fieldOrPropertyMemberName =
                XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(context.MemberInfo);
            var fieldOrPropertyNode =
                _xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{fieldOrPropertyMemberName}']");

            if (fieldOrPropertyNode == null) return;

            var summaryNode = _xmlNavigator.SelectSingleNodeRecursive(fieldOrPropertyMemberName, SummaryTag)?.SelectSingleNode(SummaryTag);
            if (summaryNode != null)
                schema.Description = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml);

            var exampleNode = _xmlNavigator.SelectSingleNodeRecursive(fieldOrPropertyMemberName, ExampleTag)?.SelectSingleNode(ExampleTag);
            if (exampleNode == null) return;
            var exampleAsJson = (schema.ResolveType(context.SchemaRepository) == "string") &&
                                !exampleNode.Value.Equals("null")
                ? $"\"{exampleNode.ToString()}\""
                : exampleNode.ToString();

            schema.Example = OpenApiAnyFactory.CreateFromJson(exampleAsJson);
        }
    }
}