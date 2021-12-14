using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public IInboundSectionPolicyBuilder Cors(Func<ICorsPolicySectionBuilder, ISectionPolicy> corsBuilder)
        {
            return Cors(a => new Dictionary<string, string>(), corsBuilder);
        }

        /// <inheritdoc />
        public IInboundSectionPolicyBuilder Cors(Func<ICorsAttributesBuilder, IDictionary<string, string>> corsAttributesBuilder, Func<ICorsPolicySectionBuilder, ISectionPolicy> corsBuilder)
        {
            var attributesBuilder = new CorsAttributesBuilder();
            var attributes = corsAttributesBuilder.Invoke(attributesBuilder);
            var corsSectionBuilder = new CorsPolicySectionBuilder(attributes);
            return AddPolicyDefinition(corsBuilder.Invoke(corsSectionBuilder));
        }
    }
}
