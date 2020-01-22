using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public class OutboundSectionPolicyBuilder : SectionBuilderBase<IOutboundSectionPolicyBuilder>,
        IOutboundSectionPolicyBuilder
    {
        public OutboundSectionPolicyBuilder(DependenciesPolicy operationPolicy) : base(operationPolicy)
        {
        }

        public IOutboundSectionPolicyBuilder SetStatus(string statusCode, string reason)
        {
            return this;
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies#StoreToCache"/>
        public IOutboundSectionPolicyBuilder CacheStore(TimeSpan cacheDuration)
        {
            return this;
        }

        public override IOutboundSectionPolicyBuilder Choose(Func<IConditionSectionBuilder<IOutboundSectionPolicyBuilder>, ISectionPolicy> conditionBuilder)
        {
            var conditionSectionBuilder = new OutboundConditionSectionBuilder(OperationPolicy);
            conditionBuilder.Invoke(conditionSectionBuilder);
            return this;
        }
    }
}