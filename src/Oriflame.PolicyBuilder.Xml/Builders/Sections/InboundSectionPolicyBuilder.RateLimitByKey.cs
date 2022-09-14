using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder RateLimitByKey(int calls, int renewalPeriod, string counterKey)
        {
            return AddPolicyDefinition(new RateLimitByKey(calls, renewalPeriod, counterKey));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder RateLimitByKey(string calls, string renewalPeriod, string counterKey)
        {
            return AddPolicyDefinition(new RateLimitByKey(calls, renewalPeriod, counterKey));
        }
    }
}
