using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder EmitMetric(string name, string value, string @namespace, Func<IEmitMetricPolicyBuilder, ISectionPolicy> action = null)
        {
            var attributes =
                new EmitMetricAttributesBuilder()
                    .Name(name)
                    .Value(value)
                    .Namespace(@namespace)
                    .Create();
            var emitMetricPolicyBuilder = new EmitMetricPolicyBuilder(attributes);
            var policy = action.Invoke(emitMetricPolicyBuilder);
            return AddPolicyDefinition(policy);
        }
    }
}
