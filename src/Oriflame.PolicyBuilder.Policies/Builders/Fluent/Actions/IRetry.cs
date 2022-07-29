using System;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSection"></typeparam>
    public interface IRetry<TSection>
    {
        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        TSection Retry(string condition, int count, TimeSpan interval, Func<TSection, ISectionPolicy> action, bool? firstFastRetry = null);
    }
}
