using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Oriflame.PolicyBuilder.Generator.Extensions
{
    public static class ApiDescriptionExtensions
    {
        public static bool TryGetMethodInfo(this ApiDescription apiDescription, out MethodInfo methodInfo)
        {
            var actionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;
            methodInfo = actionDescriptor?.MethodInfo;
            return methodInfo != null;
        }
    }
}