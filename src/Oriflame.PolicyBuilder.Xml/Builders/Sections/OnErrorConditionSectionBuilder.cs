using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class OnErrorConditionSectionBuilder : ConditionSectionBuilderBase<IOnErrorSectionPolicyBuilder>
    {
        public override IConditionSectionBuilder<IOnErrorSectionPolicyBuilder> When(string condition,
            Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> actionBuilder)
        {
            return AddPolicyDefinition(new OnErrorSectionPolicyBuilderBase(GetWhenSectionPolicy(condition)), actionBuilder);
        }

        protected override IConditionSectionBuilder<IOnErrorSectionPolicyBuilder> OtherwiseDefinition(Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> conditionSectionBuilder)
        {
            return AddPolicyDefinition(new OnErrorSectionPolicyBuilderBase(GetOtherwisePolicy()), conditionSectionBuilder);
        }
    }
}