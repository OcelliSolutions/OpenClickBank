using System.Net.Mime;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using OpenClickBank.Builder.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
    {
        //ensure all endpoints report that they only work with JSON and XML
        options.Filters.Clear();
        options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Xml));
        options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Xml));
        options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
        options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        //MapClientErrors is a .NET6 feature that automatically wraps error responses if a structure is not specified. ClickBank does not do this so it needs to be disabled.
        options.SuppressMapClientErrors = true;
    });

builder.Services.TryAddEnumerable(ServiceDescriptor
    .Transient<IApplicationModelProvider, ProduceResponseTypeModelProvider>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("1.3", new OpenApiInfo
        {
            Title = "ClickBank API",
            Version = "1.3",
            Description =
                "This document is created and maintained by the community and is designed to be a non-state specific specification. Please refer to your regions documentation for specific details and deviations." +
                "Please keep in mind that there are rate limits and other terms of use enforced by ClickBank. This document is only designed to give developers a standard used for code generation and testing."
        }
    );
    c.AddServer(new OpenApiServer { Url = "https://api.clickbank.com/rest" });
    c.EnableAnnotations(true, true);
    c.DocumentFilter<AdditionalPropertiesDocumentFilter>();
    //c.DocumentFilter<AdditionalSchemasDocumentFilter>();
    c.SchemaFilter<DateTimeSchemaFilter>();
    c.OperationFilter<AuthorizationOperationFilter>();

    // Mass apply OperationIds for the swagger doc
    c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"]}");

    // The authentication for ClickBank may look like a Basic type but in reality it is a ApiKey type.
    c.AddSecurityDefinition("ApiKey",
        new OpenApiSecurityScheme
        {
            Name = "authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "ApiKeyScheme",
            In = ParameterLocation.Header,
            Description = @"&lt;Developer API Key&gt;:&lt;Clerk API Key&gt;"
        });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            // add the Authenticate button to show on the SwaggerUI
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "ApiKey" },
                In = ParameterLocation.Header
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/1.3/swagger.json", "ClickBank API v1.3"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();