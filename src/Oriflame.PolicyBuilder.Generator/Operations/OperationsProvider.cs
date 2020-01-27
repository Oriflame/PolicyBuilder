using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Oriflame.PolicyBuilder.Generator.Extensions;
using Oriflame.PolicyBuilder.Policies;

namespace Oriflame.PolicyBuilder.Generator.Operations
{
    public class OperationsProvider : IOperationsProvider
    {
        protected readonly IApiDescriptionGroupCollectionProvider ApiDescriptionGroupCollectionProvider;

        private const string RouteSeparator = "-"; 

        public OperationsProvider(IApiDescriptionGroupCollectionProvider apiDescriptionGroupCollectionProvider)
        {
            ApiDescriptionGroupCollectionProvider = apiDescriptionGroupCollectionProvider;
        }

        public virtual string GetOperationId(MethodInfo method)
        {
            var apiDescription = ApiDescriptionGroupCollectionProvider.ApiDescriptionGroups.Items.SelectMany(
                group => group.Items).FirstOrDefault(apiDesc => apiDesc.TryGetMethodInfo(out var methodFromExplorer) && methodFromExplorer == method);
            if (apiDescription == null)
            {
                throw new InvalidOperationException($"Method {method.Name} not found by API explorer");
            }

            var route = apiDescription.ActionDescriptor.AttributeRouteInfo?.Template;

            if (route == null)
            {
                throw new InvalidOperationException($"Unable to identify route for method {method.Name}");
            }

            var encodedRoute = route.Replace("/", RouteSeparator).Replace("{", string.Empty).Replace("}", string.Empty);
            var operationId = $"{apiDescription.HttpMethod}{RouteSeparator}{encodedRoute}";
            return operationId;
        }

        public virtual IEnumerable<MethodInfo> GetOperations(Assembly assembly)
        {
            var operations=  assembly.GetTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type)) //filter controllers
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(method => !method.IsDefined(typeof(NonActionAttribute)));
            return operations;
        }

        public virtual MethodInfo GetAllOperations(Assembly assembly)
        {
            var allOperations = assembly
                    .GetTypes().FirstOrDefault(type => typeof(AllOperationsPolicyBase).IsAssignableFrom(type))?
                    .GetMethod("Create");
            return allOperations;
        }
    }
}
