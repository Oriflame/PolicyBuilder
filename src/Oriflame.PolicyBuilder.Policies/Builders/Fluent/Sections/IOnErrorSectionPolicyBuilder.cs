using System;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IOnErrorSectionPolicyBuilder : IPolicySectionBuilder<IOnErrorSectionPolicyBuilder>
    {
        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        IOnErrorSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null);
    }
}