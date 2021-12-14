using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder QuotaByKey(int calls, int bandwidth, int renewalPeriod, string counterKey)
        {
            return AddPolicyDefinition(new QuotaByKey(calls, bandwidth, renewalPeriod, counterKey));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder QuotaByKey(string calls, string bandwidth, string renewalPeriod, string counterKey)
        {
            return AddPolicyDefinition(new QuotaByKey(calls, bandwidth, renewalPeriod, counterKey));
        }
    }
}
