using System.Reflection;
using System.Threading;

namespace Oriflame.PolicyBuilder.Policies.Helpers
{
    /// <summary>
    /// Stores thread safe context of called action method
    /// It allows you to access controller action context in any level of the fluent builder
    /// </summary>
    public static class ActionContextHelper {
        
        private static readonly AsyncLocal<MethodInfo> AsyncLocalMethodInfo = new AsyncLocal<MethodInfo>();

        /// <summary>
        /// Sets method for current async context
        /// </summary>
        /// <param name="methodInfo"></param>
        public static void Set(MethodInfo methodInfo)
        {
            AsyncLocalMethodInfo.Value = methodInfo;
        }

        /// <summary>
        /// Get method from current async context
        /// </summary>
        /// <returns></returns>
        public static MethodInfo Get()
        {
            return AsyncLocalMethodInfo.Value;
        }
    }
}
