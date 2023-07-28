using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Xml;
using System.Xml.XPath;

namespace Ocelli.OpenClickBank.Builder.Filters;

/// <summary>
/// Get XML comments for controllers
/// </summary>
public class XmlCommentsDocumentFilter : IDocumentFilter
{
    private const string MemberXPath = "/doc/members/member[@name='{0}']";
    private const string SummaryTag = "summary";
    private const string InheritDocTag = "inheritdoc";

    private readonly XPathNavigator _xmlNavigator;

    /// <summary>
    /// Temporary CTOR
    /// </summary>
    /// <param name="xmlCommentsFilePath">Temporary: the source of the c# XML doc</param>
    public XmlCommentsDocumentFilter(string xmlCommentsFilePath)
    {
        var xmlDoc = new XPathDocument(xmlCommentsFilePath);
        _xmlNavigator = xmlDoc.CreateNavigator();
    }

    /// <inheritdoc />
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // Collect (unique) controller names and types in a dictionary
        var controllerNamesAndTypes = context.ApiDescriptions
            .Select(apiDesc => apiDesc.ActionDescriptor as ControllerActionDescriptor)
            .Where(actionDesc => actionDesc != null)
            .GroupBy(actionDesc => actionDesc?.ControllerName)
            .Select(group => new KeyValuePair<string, Type>(group.Key, group.First().ControllerTypeInfo.AsType()));

        foreach (var nameAndType in controllerNamesAndTypes)
        {
            var memberName = XmlCommentsNodeNameHelper.GetMemberNameForType(nameAndType.Value);
            var typeNode = _xmlNavigator.SelectSingleNode(string.Format(MemberXPath, memberName));

            var summaryNode = typeNode?.SelectSingleNode(SummaryTag);
            if (summaryNode == null) continue;
            var summaryText = ProcessInheritDocTags(summaryNode.InnerXml);
            swaggerDoc.Tags ??= new List<OpenApiTag>();

            swaggerDoc.Tags.Add(new OpenApiTag
            {
                Name = nameAndType.Key,
                Description = XmlCommentsTextHelper.Humanize(summaryText)
            });
        }
    }

    private string ProcessInheritDocTags(string xmlComments)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml($"<root>{xmlComments}</root>");

        // Find all <inheritdoc> tags
        var inheritDocNodes = xmlDoc.SelectNodes($"//{InheritDocTag}");

        if (inheritDocNodes == null) return xmlDoc.DocumentElement?.InnerXml ?? xmlComments;
        foreach (XmlNode inheritDocNode in inheritDocNodes)
        {
            var cref = inheritDocNode.Attributes?["cref"]?.Value;
            if (string.IsNullOrEmpty(cref)) continue;
            // Get the content from the referenced type
            var referencedNode = _xmlNavigator.SelectSingleNode(string.Format(MemberXPath, cref));
            if (referencedNode == null) continue;
            var summaryNode = referencedNode.SelectSingleNode(SummaryTag);
            if (summaryNode == null) continue;
            // Replace the <inheritdoc> tag with the content from the referenced type
            var replacementNode = xmlDoc.CreateElement("replacement");
            replacementNode.InnerXml = summaryNode.InnerXml;
            inheritDocNode.ParentNode?.ReplaceChild(replacementNode, inheritDocNode);
        }

        return xmlDoc.DocumentElement?.InnerXml ?? xmlComments;
    }
}
