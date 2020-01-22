using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public class OutboundConditionSectionBuilder : ConditionSectionBuilderBase<IOutboundSectionPolicyBuilder>
    {
        public OutboundConditionSectionBuilder(DependenciesPolicy operationPolicy) : base(operationPolicy)
        {
        }

        public override IConditionSectionBuilder<IOutboundSectionPolicyBuilder> When(string condition,
            Func<IOutboundSectionPolicyBuilder, ISectionPolicy> actionBuilder)
        {
            actionBuilder.Invoke(new OutboundSectionPolicyBuilder(OperationPolicy));
            return this;
        }

        protected override IConditionSectionBuilder<IOutboundSectionPolicyBuilder> OtherwiseDefinition(Func<IOutboundSectionPolicyBuilder, ISectionPolicy> conditionSectionBuilder)
        {
            conditionSectionBuilder.Invoke(new OutboundSectionPolicyBuilder(OperationPolicy));
            return this;
        }
    }
}