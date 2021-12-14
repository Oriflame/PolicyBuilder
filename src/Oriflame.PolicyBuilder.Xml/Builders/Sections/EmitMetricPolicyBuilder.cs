using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class EmitMetricPolicyBuilder : SectionBuilderBase<IEmitMetricPolicyBuilder>, IEmitMetricPolicyBuilder
    {
        public EmitMetricPolicyBuilder() : base(new SectionPolicy("emit-metric"))
        {
            // TODO ????
        }

        public IEmitMetricPolicyBuilder SetDimention(string name, string value)
        {
            return AddPolicyDefinition(new Dimention(name, value));
        }
    }
}
