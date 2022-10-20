using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IOutboundSectionPolicyBuilder : IPolicySectionBuilder<IOutboundSectionPolicyBuilder>, ISetStatus<IOutboundSectionPolicyBuilder>, IRetry<IOutboundSectionPolicyBuilder>
    {
        /// <see href="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
        IOutboundSectionPolicyBuilder SetBody(ILiquidTemplate template);

        /// <see href="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
        IOutboundSectionPolicyBuilder SetBody(string content);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies#StoreToCache"/>
        IOutboundSectionPolicyBuilder CacheStore(TimeSpan cacheDuration, Func<ICacheStoreOptionalAttributesBuilder, IDictionary<string, string>> cacheStoreOptionalAttributesBuilder = null);
        
        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies#StoreToCache"/>
        IOutboundSectionPolicyBuilder CacheStore(string cacheDuration, Func<ICacheStoreOptionalAttributesBuilder, IDictionary<string, string>> cacheStoreOptionalAttributesBuilder = null);
    }
}