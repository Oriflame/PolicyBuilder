using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder SetBody(ILiquidTemplate template)
        {
            return AddPolicyDefinition(new SetBodyLiquid(template));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder SetBody(string value)
        {
            return AddPolicyDefinition(new SetBody(value));
        }
    }
}
