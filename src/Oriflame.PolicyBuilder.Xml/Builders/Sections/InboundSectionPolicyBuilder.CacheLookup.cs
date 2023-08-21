using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public IInboundSectionPolicyBuilder CacheLookup(Func<ICacheLookupAttributesBuilder, IDictionary<string, string>> cachingAttributesBuilder,
            Func<ICacheLookupSectionBuilder, ISectionPolicy> cachingSectionPolicyBuilder = null)
        {
            if (cachingSectionPolicyBuilder == null)
            {
                cachingSectionPolicyBuilder = x => x.Create();
            }
            var attributesBuilder = new CacheLookupAttributesBuilder();
            var attributes = cachingAttributesBuilder.Invoke(attributesBuilder);
            var policyBuilder = new CacheLookupSectionBuilder(attributes);
            return AddPolicyDefinition(cachingSectionPolicyBuilder.Invoke(policyBuilder));
        }
    }
}
