using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class OutboundConditionSectionBuilder : ConditionSectionBuilderBase<IOutboundSectionPolicyBuilder>
    {
        public override IConditionSectionBuilder<IOutboundSectionPolicyBuilder> When(string condition,
            Func<IOutboundSectionPolicyBuilder, ISectionPolicy> actionBuilder)
        {
            return AddPolicyDefinition(new OutboundSectionPolicyBuilder(GetWhenSectionPolicy(condition)), actionBuilder);
        }

        protected override IConditionSectionBuilder<IOutboundSectionPolicyBuilder> OtherwiseDefinition(Func<IOutboundSectionPolicyBuilder, ISectionPolicy> conditionSectionBuilder)
        {
            return AddPolicyDefinition(new OutboundSectionPolicyBuilder(GetOtherwisePolicy()), conditionSectionBuilder);
        }
    }
}