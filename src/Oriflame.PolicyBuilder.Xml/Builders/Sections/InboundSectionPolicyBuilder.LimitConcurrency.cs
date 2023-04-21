using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder LimitConcurrency(string key, int maxCount, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action)
        {
            var limitConcurrency = new LimitConcurrency(key, maxCount);
            var innerPolicyBuilder = new InboundSectionPolicyBuilder(limitConcurrency);
            return AddPolicyDefinition(action.Invoke(innerPolicyBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder LimitConcurrency(string key, string maxCount, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action)
        {
            var limitConcurrency = new LimitConcurrency(key, maxCount);
            var innerPolicyBuilder = new InboundSectionPolicyBuilder(limitConcurrency);
            return AddPolicyDefinition(action.Invoke(innerPolicyBuilder));
        }
    }
}
