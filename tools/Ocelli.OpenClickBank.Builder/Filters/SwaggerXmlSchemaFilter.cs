using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Xml.XPath;

namespace Ocelli.OpenClickBank.Builder.Filters;

public class SwaggerXmlSchemaFilter : ISchemaFilter
{
    private const string SummaryTag = "summary";
    private readonly IServiceProvider _serviceProvider;

    public SwaggerXmlSchemaFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties == null)
            return;

        var type = context.Type;

        // Retrieve base type if the current type is a derived class
        if (type.BaseType != null && type.BaseType != typeof(object))
        {
            type = type.BaseType;
        }

        var memberName = $"T:{type.FullName}";

        // Get summary from XML comments
        var summary = GetSummaryForType(memberName);
        if (!string.IsNullOrEmpty(summary))
        {
            schema.Description = XmlCommentsTextHelper.Humanize(summary);
        }

        foreach (var entry in schema.Properties)
        {
            var propertyName = entry.Key;
            var property = type.GetProperty(propertyName);
            if (property != null)
            {
                var propertyMemberName = GetMemberNameForMember(property);

                // Get summary from XML comments for properties
                var propertySummary = GetSummaryForMember(propertyMemberName);
                if (!string.IsNullOrEmpty(propertySummary))
                {
                    entry.Value.Description = XmlCommentsTextHelper.Humanize(propertySummary);
                }
            }
        }
    }

    private string GetSummaryForType(string memberName)
    {
        var xmlDocument = GetXmlDocument();
        if (xmlDocument != null)
        {
            var node = xmlDocument.CreateNavigator().SelectSingleNode($"/doc/members/member[@name='{memberName}']/{SummaryTag}");
            if (node != null)
            {
                return node.InnerXml;
            }
        }
        return null;
    }

    private string GetSummaryForMember(string memberName)
    {
        var xmlDocument = GetXmlDocument();
        if (xmlDocument != null)
        {
            var node = xmlDocument.CreateNavigator().SelectSingleNode($"/doc/members/member[@name='{memberName}']/{SummaryTag}");
            if (node != null)
            {
                return node.InnerXml;
            }
        }
        return null;
    }

    private string GetMemberNameForMember(MemberInfo member)
    {
        return $"{(member is PropertyInfo ? "P" : "F")}:{member.DeclaringType.FullName}.{member.Name}";
    }

    private XPathNavigator GetXmlDocument()
    {
        var options = _serviceProvider.GetRequiredService<IOptions<SwaggerGenOptions>>();
        var schemaFilterDescriptors = options.Value.SchemaFilterDescriptors;

        foreach (var filterDescriptor in schemaFilterDescriptors)
        {
            if (filterDescriptor.Type == typeof(XmlCommentsSchemaFilter))
            {
                foreach (var argument in filterDescriptor.Arguments)
                {
                    if (argument is XPathDocument xmlDocument)
                    {
                        return xmlDocument.CreateNavigator();
                    }
                }
            }
        }
        return null;
    }
}
