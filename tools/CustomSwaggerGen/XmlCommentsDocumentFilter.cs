using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Xml.XPath;

namespace CustomSwaggerGen
{
    public class XmlCommentsDocumentFilter : IDocumentFilter
    {
        private const string SummaryTag = "summary";

        private readonly XPathNavigator _xmlNavigator;

        public XmlCommentsDocumentFilter(XPathDocument xmlDoc)
        {
            _xmlNavigator = xmlDoc.CreateNavigator();
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Collect (unique) controller names and types in a dictionary
            var controllerNamesAndTypes = context.ApiDescriptions
                .Select(apiDesc => apiDesc.ActionDescriptor as ControllerActionDescriptor)
                .Where(actionDesc => actionDesc != null)
                .GroupBy(actionDesc => actionDesc.ControllerName)
                .Select(group => new KeyValuePair<string, Type>(group.Key, group.First().ControllerTypeInfo.AsType()));

            foreach (var nameAndType in controllerNamesAndTypes)
            {
                var memberName = XmlCommentsNodeNameHelper.GetMemberNameForType(nameAndType.Value);
                //var typeNode = _xmlNavigator.SelectSingleNode(string.Format(MemberXPath, memberName));
                var summaryNode = _xmlNavigator.SelectSingleNodeRecursive(memberName, SummaryTag)?.SelectSingleNode(SummaryTag);
                if (summaryNode == null) continue;
                if (swaggerDoc.Tags == null) 
                    swaggerDoc.Tags = new List<OpenApiTag>();

                swaggerDoc.Tags.Add(new OpenApiTag
                {
                    Name = nameAndType.Key, Description = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml)
                });
            }
        }
    }
}