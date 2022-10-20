using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, string count, TimeSpan interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, string count, string interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, int count, string interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, string firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, string count, string interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, string firstFastRetry = null)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }
    }
}