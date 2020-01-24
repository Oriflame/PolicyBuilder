using System.Collections.Generic;
using System.Reflection;

namespace Oriflame.PolicyBuilder.Generator.Operations
{
    public interface IOperationsProvider
    {
        /// <summary>
        /// Provides unique Id of an endpoint
        /// </summary>
        string GetOperationId(MethodInfo method);

        /// <summary>
        /// Provides all methods (endpoints) from the assembly
        /// </summary>
        IEnumerable<MethodInfo> GetOperations(Assembly assembly);

        /// <summary>
        /// Provides a method which contains policy for All Operations policy of the API
        /// </summary>
        MethodInfo GetAllOperations(Assembly assembly);
    }
}