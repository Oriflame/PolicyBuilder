using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder SetQueryParameter(string name, string value, ExistsAction? existsAction)
        {
            return AddPolicyDefinition(new SetQueryParameter(name, value, existsAction));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder DeleteQueryParameter(string name)
        {
            return AddPolicyDefinition(new DeleteQueryParameter(name));
        }
    }
}