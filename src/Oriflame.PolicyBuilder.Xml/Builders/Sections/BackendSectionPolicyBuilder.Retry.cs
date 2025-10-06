using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.Expressions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(Expression condition, int count, TimeSpan interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(Expression condition, Expression count, TimeSpan interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(Expression condition, Expression count, Expression interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(Expression condition, int count, Expression interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(Expression condition, int count, TimeSpan interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, Expression firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(Expression condition, Expression count, Expression interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, Expression firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }
    }
}