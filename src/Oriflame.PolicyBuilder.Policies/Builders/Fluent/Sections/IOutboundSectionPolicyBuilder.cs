using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IOutboundSectionPolicyBuilder : IPolicySectionBuilder<IOutboundSectionPolicyBuilder>, ISetStatus<IOutboundSectionPolicyBuilder>
    {
        /// <see href="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
        IOutboundSectionPolicyBuilder SetBody(ILiquidTemplate template);

        /// <see href="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
        IOutboundSectionPolicyBuilder SetBody(string content);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        IOutboundSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IOutboundSectionPolicyBuilder, ISectionPolicy> action, bool firstFastRetry = false);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies#StoreToCache"/>
        IOutboundSectionPolicyBuilder CacheStore(TimeSpan cacheDuration);
    }
}