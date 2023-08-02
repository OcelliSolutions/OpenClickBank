using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Xml.XPath;

namespace CustomSwaggerGen
{
    public class XmlCommentsOperationFilter : IOperationFilter
    {
        private readonly XPathNavigator _xmlNavigator;
        private const string SummaryTag = "summary";
        private const string RemarksTag = "remarks";
        private const string ResponseTag = "response";

        public XmlCommentsOperationFilter(XPathDocument xmlDoc)
        {
            _xmlNavigator = xmlDoc.CreateNavigator();
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo == null) return;

            // If method is from a constructed generic type, look for comments from the generic type method
            var targetMethod = context.MethodInfo.DeclaringType.IsConstructedGenericType
                ? context.MethodInfo.GetUnderlyingGenericTypeMethod()
                : context.MethodInfo;

            if (targetMethod == null) return;

            ApplyControllerTags(operation, targetMethod.DeclaringType);
            ApplyMethodTags(operation, targetMethod);
        }

        private void ApplyControllerTags(OpenApiOperation operation, Type controllerType)
        {
            var typeMemberName = XmlCommentsNodeNameHelper.GetMemberNameForType(controllerType);
            var typeNode = _xmlNavigator.SelectSingleNodeRecursive(typeMemberName, ResponseTag);
            var responseNodes = typeNode?.Select(ResponseTag);
            if (responseNodes == null) return;
            ApplyResponseTags(operation, responseNodes);
        }

        private void ApplyMethodTags(OpenApiOperation operation, MethodInfo methodInfo)
        {
            var methodMemberName = XmlCommentsNodeNameHelper.GetMemberNameForMethod(methodInfo);

            var summaryNode = _xmlNavigator.SelectSingleNodeRecursive(methodMemberName, SummaryTag)
                ?.SelectSingleNode(SummaryTag);
            if (summaryNode != null)
                operation.Summary = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml);

            var remarksNode = _xmlNavigator.SelectSingleNodeRecursive(methodMemberName, RemarksTag)
                ?.SelectSingleNode(RemarksTag);
            if (remarksNode != null)
                operation.Description = XmlCommentsTextHelper.Humanize(remarksNode.InnerXml);

            var responseNodes = _xmlNavigator.SelectSingleNodeRecursive(methodMemberName, ResponseTag)
                ?.Select(ResponseTag);
            if (responseNodes != null)
                ApplyResponseTags(operation, responseNodes);
        }

        private void ApplyResponseTags(OpenApiOperation operation, XPathNodeIterator responseNodes)
        {
            while (responseNodes.MoveNext())
            {
                var code = responseNodes.Current.GetAttribute("code", "");
                var response = operation.Responses.ContainsKey(code)
                    ? operation.Responses[code]
                    : operation.Responses[code] = new OpenApiResponse();

                response.Description = XmlCommentsTextHelper.Humanize(responseNodes.Current.InnerXml);
            }
        }
    }
}