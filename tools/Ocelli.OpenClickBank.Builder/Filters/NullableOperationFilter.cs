using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ocelli.OpenClickBank.Builder.Filters;

public class NullableOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        foreach (var response in operation.Responses)
        {
            if (response.Key != "206" && response.Key != "200")
                continue;

            if (response.Value.Content == null)
                continue;

            if (!response.Value.Content.TryGetValue("application/json", out var json))
                continue;
            if(json?.Schema?.Reference?.Id == null)
                continue;
            context.SchemaRepository.Schemas[json.Schema.Reference.Id].Nullable = true;
        }
    }
}

