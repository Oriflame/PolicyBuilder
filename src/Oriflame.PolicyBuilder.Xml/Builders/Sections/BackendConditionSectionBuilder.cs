using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class BackendConditionSectionBuilder : ConditionSectionBuilderBase<IBackendSectionPolicyBuilder>
    {
        public override IConditionSectionBuilder<IBackendSectionPolicyBuilder> When(string condition,
            Func<IBackendSectionPolicyBuilder, ISectionPolicy> actionBuilder)
        {
            return AddPolicyDefinition(new BackendSectionPolicyBuilder(GetWhenSectionPolicy(condition)), actionBuilder);
        }

        protected override IConditionSectionBuilder<IBackendSectionPolicyBuilder> OtherwiseDefinition(Func<IBackendSectionPolicyBuilder, ISectionPolicy> conditionSectionBuilder)
        {
            return AddPolicyDefinition(new BackendSectionPolicyBuilder(GetOtherwisePolicy()), conditionSectionBuilder);
        }
    }
}