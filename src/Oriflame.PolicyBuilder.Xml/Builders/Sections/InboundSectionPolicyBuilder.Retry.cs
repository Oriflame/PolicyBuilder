using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.Expressions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(Expression condition, int count, TimeSpan interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(Expression condition, Expression count, TimeSpan interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(Expression condition, int count, Expression interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(Expression condition, int count, TimeSpan interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            Expression firstFastRetry)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(Expression condition, Expression count, Expression interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(Expression condition, Expression count, Expression interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            Expression firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }
    }
}
