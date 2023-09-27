﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Filters;

/// <summary>
/// Use the EnumMemberValue when creating the OpenApi spec. This allows for us to have valid enum values but still match what ClickBank uses.
/// </summary>
public class DescribeEnumMemberValuesFilter : ISchemaFilter
{
    /// <inheritdoc />
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsEnum)
        {
            schema.Enum.Clear();

            //Retrieve each of the values decorated with an EnumMember attribute
            foreach (var member in context.Type.GetMembers())
            {
                var memberAttr = member.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault();
                if (memberAttr != null)
                {
                    var attr = (EnumMemberAttribute)memberAttr;
                    schema.Enum.Add(new OpenApiString(attr.Value));
                }
            }
        }
    }
}