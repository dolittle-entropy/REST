using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Routing;

namespace TestApp
{
    public class CustomController
    {
        public void Perform()
        {
            var i = 0;
            i++;
            
        }
    }


    public class CustomActionDescriptorProvider : IActionDescriptorProvider
    {
        public CustomActionDescriptorProvider()
        {
            
        }

        public int Order => 0;

        public void OnProvidersExecuted(ActionDescriptorProviderContext context)
        {
            var i = 0;
            i++;
        }

        public void OnProvidersExecuting(ActionDescriptorProviderContext context)
        {
            var descriptor = new ControllerActionDescriptor
            {
                ControllerName = "Awesome",
                DisplayName = "ItsDaCustomThingy",
                ActionName = "DoStuff",
                ControllerTypeInfo = typeof(CustomController).GetTypeInfo(),
                MethodInfo = typeof(CustomController).GetTypeInfo().GetMethod("Perform"),
                AttributeRouteInfo = new AttributeRouteInfo { Template = "api/Awesome" },
                ActionConstraints = new List<IActionConstraintMetadata> {
                  new HttpMethodActionConstraint(new[] { "POST"} )
                },
                FilterDescriptors = new List<FilterDescriptor> {
                    new FilterDescriptor(new ControllerActionFilter(),0)
                },
                RouteValues = {
                    { "action", "DoStuff"},
                    { "controller", "Awesome"}
                },
                Properties = {
                    { typeof(ApiDescriptionActionData), new ApiDescriptionActionData() }
                },
                Parameters = new List<ParameterDescriptor>(),
                BoundProperties = new List<ParameterDescriptor>()
            };
            context.Results.Add(descriptor);

            descriptor = new ControllerActionDescriptor
            {
                ControllerName = "Awesome",
                DisplayName = "MoreThings",
                ActionName = "DoMoreStuff",
                ControllerTypeInfo = typeof(CustomController).GetTypeInfo(),
                MethodInfo = typeof(CustomController).GetTypeInfo().GetMethod("Perform"),
                AttributeRouteInfo = new AttributeRouteInfo { Template = "api/Awesome" },
                ActionConstraints = new List<IActionConstraintMetadata> {
                  new HttpMethodActionConstraint(new[] { "PUT"} )
                },
                FilterDescriptors = new List<FilterDescriptor> {
                    new FilterDescriptor(new ControllerActionFilter(),0)
                },
                RouteValues = {
                    { "action", "DoMoreStuff"},
                    { "controller", "Awesome"}
                },
                Properties = {
                    { typeof(ApiDescriptionActionData), new ApiDescriptionActionData() }
                },
                Parameters = new List<ParameterDescriptor>(),
                BoundProperties = new List<ParameterDescriptor>()
            };
            context.Results.Add(descriptor);
        }
    }
}