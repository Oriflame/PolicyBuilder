using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes
{
    public class EmitMetricAttributesBuilder : AttributesBuilderBase<IEmitMetricAttributesBuilder>, IEmitMetricAttributesBuilder
    {
        public IEmitMetricAttributesBuilder Name(string name)
        {
            return AddAttribute("name", name);
        }

        public IEmitMetricAttributesBuilder Value(string value)
        {
            return AddAttribute("value", value);
        }

        public IEmitMetricAttributesBuilder Namespace(string @namespace)
        {
            return AddAttribute("namespace", @namespace);
        }
    }
}