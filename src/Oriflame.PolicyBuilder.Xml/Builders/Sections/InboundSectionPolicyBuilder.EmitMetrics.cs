using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder EmitMetric(string name, string value, string @namespace, Func<IEmitMetricPolicyBuilder, ISectionPolicy> action = null)
        {
            // TODO
            var emitMetricPolicyBuilder = new EmitMetricPolicyBuilder();
            var innerPolicy = action.Invoke(emitMetricPolicyBuilder);
            var policy = new EmitMetricPolicy(name, value, @namespace, innerPolicy);
            return AddPolicyDefinition(policy);
        }
    }
}
