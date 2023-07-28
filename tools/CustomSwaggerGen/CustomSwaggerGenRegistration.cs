using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CustomSwaggerGen
{
    public static class CustomSwaggerGenRegistration
    {// create a registration method that can add all the filters to the swagger generator
        public static void AddCustomSwaggerGenFilters(this SwaggerGenOptions options)
        {
            options.DocumentFilter<XmlCommentsDocumentFilter>();
            options.OperationFilter<XmlCommentsOperationFilter>();
            options.ParameterFilter<XmlCommentsParameterFilter>();
            options.RequestBodyFilter<XmlCommentsRequestBodyFilter>();
            options.SchemaFilter<XmlCommentsSchemaFilter>();
        }
    }
}
