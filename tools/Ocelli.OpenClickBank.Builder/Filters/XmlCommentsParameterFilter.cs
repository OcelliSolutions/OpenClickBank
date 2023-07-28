using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Xml.XPath;

namespace Ocelli.OpenClickBank.Builder.Filters;
/// <summary>
/// Get XML comments for controller method parameters
/// </summary>
public class XmlCommentsParameterFilter : IParameterFilter
{
    private readonly XPathNavigator _xmlNavigator;

    /// <summary>
    /// Temporary CTOR
    /// </summary>
    /// <param name="xmlCommentsFilePath">Temporary: the source of the c# XML doc</param>
    public XmlCommentsParameterFilter(string xmlCommentsFilePath)
    {
        var xmlDoc = new XPathDocument(xmlCommentsFilePath);
        _xmlNavigator = xmlDoc.CreateNavigator();
    }

    /// <inheritdoc />
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (context.PropertyInfo != null)
        {
            ApplyPropertyTags(parameter, context);
        }
        else if (context.ParameterInfo != null)
        {
            ApplyParamTags(parameter, context);
        }
    }

    private void ApplyPropertyTags(OpenApiParameter parameter, ParameterFilterContext context)
    {
        var propertyMemberName = XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(context.PropertyInfo);
        var propertyNode = _xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{propertyMemberName}']");

        if (propertyNode == null) return;

        var summaryNode = propertyNode.SelectSingleNode("summary");
        if (summaryNode != null)
        {
            parameter.Description = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml);
            parameter.Schema.Description = null; // no need to duplicate
        }

        var exampleNode = propertyNode.SelectSingleNode("example");
        if (exampleNode == null) return;

        var exampleAsJson = (parameter.Schema?.ResolveType(context.SchemaRepository) == "string")
            ? $"\"{exampleNode.ToString()}\""
            : exampleNode.ToString();

        parameter.Example = OpenApiAnyFactory.CreateFromJson(exampleAsJson);
    }

    private void ApplyParamTags(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (!(context.ParameterInfo.Member is MethodInfo methodInfo)) return;

        // If method is from a constructed generic type, look for comments from the generic type method
        var targetMethod = methodInfo.DeclaringType.IsConstructedGenericType
            ? methodInfo.GetUnderlyingGenericTypeMethod()
            : methodInfo;

        if (targetMethod == null) return;

        var methodMemberName = XmlCommentsNodeNameHelper.GetMemberNameForMethod(targetMethod);
        //var paramNode = _xmlNavigator.SelectSingleNode(
        //    $"/doc/members/member[@name='{methodMemberName}']/param[@name='{context.ParameterInfo.Name}']");
        var paramNode = GetParamNode(methodMemberName, context.ParameterInfo.Name);

        if (paramNode != null)
        {
            parameter.Description = XmlCommentsTextHelper.Humanize(paramNode.InnerXml);

            var example = paramNode.GetAttribute("example", "");
            if (string.IsNullOrEmpty(example)) return;

            var exampleAsJson = (parameter.Schema?.ResolveType(context.SchemaRepository) == "string")
                ? $"\"{example}\""
                : example;

            parameter.Example = OpenApiAnyFactory.CreateFromJson(exampleAsJson);
        }
    }
    private XPathNavigator? GetParamNode(string methodMemberName, string? paramName)
    {
        var memberNode = _xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{methodMemberName}']");

        // Check if there is an <inheritdoc> element
        var inheritDocNode = memberNode?.SelectSingleNode("inheritdoc");
        if (inheritDocNode == null) return memberNode?.SelectSingleNode($"param[@name='{paramName}']");
        var cref = inheritDocNode.GetAttribute("cref", "");
        if (string.IsNullOrEmpty(cref)) return memberNode?.SelectSingleNode($"param[@name='{paramName}']");
        // Traverse to the referenced member using the cref attribute
        var referencedNode = _xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{cref}']");

        // Find the specific <param> element with the matching 'name' attribute inside the referenced member
        var paramNode = referencedNode?.SelectSingleNode($"param[@name='{paramName}']");
        return paramNode ??
               // If the <param> element is not found in the referenced member, fall back to the original member
               memberNode?.SelectSingleNode($"param[@name='{paramName}']");
    }
    
}

