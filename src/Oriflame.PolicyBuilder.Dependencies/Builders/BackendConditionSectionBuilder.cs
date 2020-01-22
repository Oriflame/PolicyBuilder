using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public class BackendConditionSectionBuilder : ConditionSectionBuilderBase<IBackendSectionPolicyBuilder>
    {
        public BackendConditionSectionBuilder(DependenciesPolicy operationPolicy) : base(operationPolicy)
        {
        }

        public override IConditionSectionBuilder<IBackendSectionPolicyBuilder> When(string condition,
            Func<IBackendSectionPolicyBuilder, ISectionPolicy> actionBuilder)
        {
            actionBuilder.Invoke(new BackendSectionPolicyBuilder(OperationPolicy));
            return this;
        }

        protected override IConditionSectionBuilder<IBackendSectionPolicyBuilder> OtherwiseDefinition(Func<IBackendSectionPolicyBuilder, ISectionPolicy> conditionSectionBuilder)
        {
            conditionSectionBuilder.Invoke(new BackendSectionPolicyBuilder(OperationPolicy));
            return this;
        }
    }
}