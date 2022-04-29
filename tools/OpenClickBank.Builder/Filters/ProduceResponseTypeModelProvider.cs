﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace OpenClickBank.Builder.Filters;

public class ProduceResponseTypeModelProvider : IApplicationModelProvider
{
    public int Order => 3;

    public void OnProvidersExecuted(ApplicationModelProviderContext context)
    {
    }

    public void OnProvidersExecuting(ApplicationModelProviderContext context)
    {
        foreach (var controller in context.Result.Controllers)
        foreach (var action in controller.Actions)
        {
            var returnType = typeof(string);
            if (action.ActionMethod.ReturnType.GenericTypeArguments.Any())
            {
                if (action.ActionMethod.ReturnType.GenericTypeArguments[0].GetGenericArguments().Any())
                    returnType = action.ActionMethod.ReturnType.GenericTypeArguments[0].GetGenericArguments()[0];
            }

            var methodVerbs = action.Attributes.OfType<HttpMethodAttribute>().SelectMany(x => x.HttpMethods).Distinct();

            AddUniversalStatusCodes(action, returnType);

            //if (!methodVerbs.Contains("GET")) //POST, PUT, DELETE all have these.
            //    AddPostStatusCodes(action, returnType);
        }
    }

    public void AddProducesResponseTypeAttribute(ActionModel action, Type? returnType, int statusCodeResult)
    {
        if (returnType != null)
            action.Filters.Add(new ProducesResponseTypeAttribute(returnType, statusCodeResult, "plain/text"));
        else if (returnType == null) action.Filters.Add(new ProducesResponseTypeAttribute(statusCodeResult));
    }

    public void AddUniversalStatusCodes(ActionModel action, Type returnType)
    {
        //AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status400BadRequest);
        //AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status401Unauthorized);
        AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status403Forbidden);
        //AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status404NotFound);
        //AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status429TooManyRequests);
        //AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status500InternalServerError);

        //these will never return a response code, however, it makes exception handling easier if they have a nullable response instead of none at all
        //AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status503ServiceUnavailable);
    }

    public void AddPostStatusCodes(ActionModel action, Type returnType)
    {
        AddProducesResponseTypeAttribute(action, null, StatusCodes.Status200OK);
        AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status400BadRequest);
        AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status404NotFound);
    }
}