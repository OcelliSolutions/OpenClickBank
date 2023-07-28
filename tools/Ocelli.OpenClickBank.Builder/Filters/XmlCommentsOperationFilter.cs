using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Xml.XPath;

namespace Ocelli.OpenClickBank.Builder.Filters;

/// <summary>
/// Get XML comments for controller methods
/// </summary>
public class XmlCommentsOperationFilter : IOperationFilter
{
    private readonly XPathNavigator _xmlNavigator;

    /// <summary>
    /// Temporary CTOR
    /// </summary>
    /// <param name="xmlCommentsFilePath">Temporary: the source of the c# XML doc</param>
    public XmlCommentsOperationFilter(string xmlCommentsFilePath)
    {
        var xmlDoc = new XPathDocument(xmlCommentsFilePath);
        _xmlNavigator = xmlDoc.CreateNavigator();
    }

    /// <inheritdoc />
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.MethodInfo == null) return;

        // If method is from a constructed generic type, look for comments from the generic type method
        var targetMethod = context.MethodInfo.DeclaringType is { IsConstructedGenericType: true }
            ? context.MethodInfo.GetUnderlyingGenericTypeMethod()
            : context.MethodInfo;

        if (targetMethod == null) return;

        if (targetMethod.DeclaringType != null) 
            ApplyControllerTags(operation, targetMethod.DeclaringType);
        ApplyMethodTags(operation, targetMethod);
    }

    private void ApplyControllerTags(OpenApiOperation operation, Type controllerType)
    {
        var typeMemberName = XmlCommentsNodeNameHelper.GetMemberNameForType(controllerType);
        var responseNodes = _xmlNavigator.Select($"/doc/members/member[@name='{typeMemberName}']/response");
        ApplyResponseTags(operation, responseNodes);
    }

    private void ApplyMethodTags(OpenApiOperation operation, MethodInfo methodInfo)
    {
        var methodMemberName = XmlCommentsNodeNameHelper.GetMemberNameForMethod(methodInfo);
        var methodNode = _xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{methodMemberName}']");

        if (methodNode == null) return;

        ApplyMethodTagsRecursively(operation, methodNode);
    }

    private void ApplyMethodTagsRecursively(OpenApiOperation operation, XPathNavigator methodNode)
    {
        var summaryNode = methodNode.SelectSingleNode("summary");
        if (summaryNode != null)
            operation.Summary = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml);

        var remarksNode = methodNode.SelectSingleNode("remarks");
        if (remarksNode != null)
            operation.Description = XmlCommentsTextHelper.Humanize(remarksNode.InnerXml);

        var responseNodes = methodNode.Select("response");
        ApplyResponseTags(operation, responseNodes);

        var inheritDocNode = methodNode.SelectSingleNode("inheritdoc");
        if (inheritDocNode == null) return;
        var cref = inheritDocNode.GetAttribute("cref", "");
        if (string.IsNullOrEmpty(cref)) return;
        var referencedNode = _xmlNavigator.SelectSingleNode($"/doc/members/member[@name='{cref}']");
        if (referencedNode != null)
        {
            ApplyMethodTagsRecursively(operation, referencedNode);
        }
    }

    private static void ApplyResponseTags(OpenApiOperation operation, XPathNodeIterator responseNodes)
    {
        while (responseNodes.MoveNext())
        {
            var code = responseNodes.Current?.GetAttribute("code", "");
            var response = operation.Responses.ContainsKey(code)
                ? operation.Responses[code]
                : operation.Responses[code] = new OpenApiResponse();

            response.Description = XmlCommentsTextHelper.Humanize(responseNodes.Current?.InnerXml);
        }
    }
}

