using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class OnErrorSectionPolicyBuilderBase : SectionBuilderBase<IOnErrorSectionPolicyBuilder>, IOnErrorSectionPolicyBuilder
    {
        public OnErrorSectionPolicyBuilderBase(ISectionPolicy sectionPolicy) : base(sectionPolicy)
        {
        }

        public override IOnErrorSectionPolicyBuilder Choose(Func<IConditionSectionBuilder<IOnErrorSectionPolicyBuilder>, ISectionPolicy> conditionBuilder)
        {
            var conditionSectionBuilder = new OnErrorConditionSectionBuilder();
            return AddPolicyDefinition(conditionBuilder.Invoke(conditionSectionBuilder));
        }

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        public IOnErrorSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> action,
            bool firstFastRetry = false)
        {
            var actionBuilder = new OnErrorSectionPolicyBuilderBase(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }
    }
}