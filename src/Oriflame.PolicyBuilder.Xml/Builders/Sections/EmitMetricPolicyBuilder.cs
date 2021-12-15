using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class EmitMetricPolicyBuilder : SectionBuilderBase<IEmitMetricPolicyBuilder>, IEmitMetricPolicyBuilder
    {
        public EmitMetricPolicyBuilder(IDictionary<string, string> attributes) : base(new SectionPolicy("emit-metric", attributes))
        {
        }

        public IEmitMetricPolicyBuilder Dimension(string name, string value)
        {
            return AddPolicyDefinition(new Dimension(name, value));
        }
    }
}
