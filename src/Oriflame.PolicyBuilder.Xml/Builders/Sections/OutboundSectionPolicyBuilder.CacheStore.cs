using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Extensions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class OutboundSectionPolicyBuilder : SectionBuilderBase<IOutboundSectionPolicyBuilder>, IOutboundSectionPolicyBuilder
    {
        
        /// <inheritdoc />
        public virtual IOutboundSectionPolicyBuilder CacheStore(TimeSpan cacheDuration, Func<ICacheStoreOptionalAttributesBuilder, IDictionary<string, string>> cacheStoreOptionalAttributesBuilder = null)
        {
            return CacheStore(cacheDuration.GetSeconds(), cacheStoreOptionalAttributesBuilder);
        }
        
        /// <inheritdoc />
        public virtual IOutboundSectionPolicyBuilder CacheStore(string cacheDuration, Func<ICacheStoreOptionalAttributesBuilder, IDictionary<string, string>> cacheStoreOptionalAttributesBuilder = null)
        {
            var attributesBuilder = new CacheStoreOptionalAttributesBuilder();
            var attributes = cacheStoreOptionalAttributesBuilder?.Invoke(attributesBuilder);
            var policy = new CacheStore(cacheDuration, attributes);
            return AddPolicyDefinition(policy);
        }
    }
}