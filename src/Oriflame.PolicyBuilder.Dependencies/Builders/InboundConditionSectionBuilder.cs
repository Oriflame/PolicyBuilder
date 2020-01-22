using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public class InboundConditionSectionBuilder : ConditionSectionBuilderBase<IInboundSectionPolicyBuilder>
    {
        public InboundConditionSectionBuilder(DependenciesPolicy operationPolicy) : base(operationPolicy)
        {
        }

        public override IConditionSectionBuilder<IInboundSectionPolicyBuilder> When(string condition,
            Func<IInboundSectionPolicyBuilder, ISectionPolicy> actionBuilder)
        {
            actionBuilder.Invoke(new InboundSectionPolicyBuilder(OperationPolicy));
            return this;
        }

        protected override IConditionSectionBuilder<IInboundSectionPolicyBuilder> OtherwiseDefinition(Func<IInboundSectionPolicyBuilder, ISectionPolicy> conditionSectionBuilder)
        {
            conditionSectionBuilder.Invoke(new InboundSectionPolicyBuilder(OperationPolicy));
            return this;
        }
    }
}