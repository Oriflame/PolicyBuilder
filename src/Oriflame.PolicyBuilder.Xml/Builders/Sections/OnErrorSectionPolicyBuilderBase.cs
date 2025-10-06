using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.Expressions;
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

        /// <inheritdoc />
        public IOnErrorSectionPolicyBuilder Retry(Expression condition, int count, TimeSpan interval, Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new OnErrorSectionPolicyBuilderBase(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public IOnErrorSectionPolicyBuilder Retry(Expression condition, Expression count, TimeSpan interval, Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new OnErrorSectionPolicyBuilderBase(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public IOnErrorSectionPolicyBuilder Retry(Expression condition, int count, Expression interval, Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new OnErrorSectionPolicyBuilderBase(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public IOnErrorSectionPolicyBuilder Retry(Expression condition, int count, TimeSpan interval, Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> action, Expression firstFastRetry)
        {
            var actionBuilder = new OnErrorSectionPolicyBuilderBase(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public IOnErrorSectionPolicyBuilder Retry(Expression condition, Expression count, Expression interval, Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> action, Expression firstFastRetry)
        {
            var actionBuilder = new OnErrorSectionPolicyBuilderBase(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public IOnErrorSectionPolicyBuilder Retry(Expression condition, Expression count, Expression interval, Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new OnErrorSectionPolicyBuilderBase(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }
    }
}