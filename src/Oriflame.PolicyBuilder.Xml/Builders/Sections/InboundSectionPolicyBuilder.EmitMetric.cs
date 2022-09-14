using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder EmitMetric(string name, string value = null, string @namespace = null, Func<IEmitMetricPolicyBuilder, ISectionPolicy> action = null)
        {
            var attributeBuilder = new EmitMetricAttributesBuilder();
            attributeBuilder.Name(name);

            if (!string.IsNullOrEmpty(value))
            {
                attributeBuilder.Value(value);
            }

            if (!string.IsNullOrEmpty(@namespace))
            {
                attributeBuilder.Namespace(@namespace);
            }

            var emitMetricPolicyBuilder = new EmitMetricPolicyBuilder(attributeBuilder.Create());
            var policy = action?.Invoke(emitMetricPolicyBuilder);
            return AddPolicyDefinition(policy);
        }
    }
}
