using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class InboundConditionSectionBuilder : ConditionSectionBuilderBase<IInboundSectionPolicyBuilder>
    {
        public override IConditionSectionBuilder<IInboundSectionPolicyBuilder> When(string condition,
            Func<IInboundSectionPolicyBuilder, ISectionPolicy> actionBuilder)
        {
            return AddPolicyDefinition(new InboundSectionPolicyBuilder(GetWhenSectionPolicy(condition)), actionBuilder);
        }

        protected override IConditionSectionBuilder<IInboundSectionPolicyBuilder> OtherwiseDefinition(Func<IInboundSectionPolicyBuilder, ISectionPolicy> conditionSectionBuilder)
        {
            return AddPolicyDefinition(new InboundSectionPolicyBuilder(GetOtherwisePolicy()), conditionSectionBuilder);
        }
    }
}