using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>,
        IBackendSectionPolicyBuilder
    {
        private const string DefaultDestination = "Online";

        public BackendSectionPolicyBuilder(DependenciesPolicy operationPolicy) : base(operationPolicy)
        {
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#ForwardRequest"/>
        public IBackendSectionPolicyBuilder ForwardRequest(TimeSpan? timeout)
        {
            return this;
        }

        public override IBackendSectionPolicyBuilder Choose(Func<IConditionSectionBuilder<IBackendSectionPolicyBuilder>, ISectionPolicy> conditionBuilder)
        {
            var conditionSectionBuilder = new BackendConditionSectionBuilder(OperationPolicy);
            conditionBuilder.Invoke(conditionSectionBuilder);
            return this;
        }

        public override IBackendSectionPolicyBuilder Base()
        {
            if (string.IsNullOrEmpty(OperationPolicy.Primary.Destination))
            {
                OperationPolicy.Primary.SetDestination(DefaultDestination);
            }
            return this;
        }
    }
}