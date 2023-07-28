using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Xml.XPath;

namespace Ocelli.OpenClickBank.Builder.Filters;

/// <summary>
/// Get XML comments for controller method parameters
/// </summary>
public class XmlCommentsSchemaFilter : ISchemaFilter
{
    private readonly XPathNavigator _xmlNavigator;

    /// <summary>
    /// Temporary CTOR
    /// </summary>
    /// <param name="xmlCommentsFilePath">Temporary: the source of the c# XML doc</param>
    public XmlCommentsSchemaFilter(string xmlCommentsFilePath)
    {
        var xmlDoc = new XPathDocument(xmlCommentsFilePath);
        _xmlNavigator = xmlDoc.CreateNavigator();
    }

    /// <inheritdoc />
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        ApplyTypeTags(schema, context.Type);

        if (context.MemberInfo != null)
        {
            ApplyMemberTags(schema, context.MemberInfo);
        }
    }

    private void ApplyTypeTags(OpenApiSchema schema, Type type)
    {
        var typeMemberName = XmlCommentsNodeNameHelper.GetMemberNameForType(type);
        var typeSummaryNode = _xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{typeMemberName}']/summary");

        if (typeSummaryNode != null)
        {
            schema.Description = XmlCommentsTextHelper.Humanize(typeSummaryNode.InnerXml);
        }
    }

    private void ApplyMemberTags(OpenApiSchema schema, MemberInfo memberInfo)
    {
        var fieldOrPropertyMemberName = XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(memberInfo);
        var fieldOrPropertyNode = _xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{fieldOrPropertyMemberName}']");

        if (fieldOrPropertyNode == null) return;

        ApplyMemberTagsRecursively(schema, fieldOrPropertyNode);
    }

    private void ApplyMemberTagsRecursively(OpenApiSchema schema, XPathNavigator memberNode)
    {
        var summaryNode = memberNode.SelectSingleNode("summary");
        if (summaryNode != null)
            schema.Description = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml);

        var exampleNode = memberNode.SelectSingleNode("example");
        if (exampleNode != null)
        {
            var exampleAsJson = (schema.ResolveType(null) == "string") && !exampleNode.Value.Equals("null")
                ? $"\"{exampleNode}\""
                : exampleNode.ToString();

            schema.Example = OpenApiAnyFactory.CreateFromJson(exampleAsJson);
        }

        var inheritDocNode = memberNode.SelectSingleNode("inheritdoc");
        if (inheritDocNode == null) return;
        var cref = inheritDocNode.GetAttribute("cref", "");
        if (string.IsNullOrEmpty(cref)) return;
        var referencedNode = _xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{cref}']");
        if (referencedNode != null)
        {
            ApplyMemberTagsRecursively(schema, referencedNode);
        }
    }
}

