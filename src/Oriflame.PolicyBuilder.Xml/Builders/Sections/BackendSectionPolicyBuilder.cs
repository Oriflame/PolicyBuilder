using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        public BackendSectionPolicyBuilder(ISectionPolicy sectionPolicy) : base(sectionPolicy)
        {
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder SetBackendService(string url)
        {
            return AddPolicyDefinition(new SetBackendService(url));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder SetQueryParameter(string name, string value, ExistsAction? existsAction)
        {
            return AddPolicyDefinition(new SetQueryParameter(name, value, existsAction));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder SetBody(ILiquidTemplate template)
        {
            return AddPolicyDefinition(new SetBodyLiquid(template));
        }

        /// <inheritdoc />
        public override IBackendSectionPolicyBuilder Choose(Func<IConditionSectionBuilder<IBackendSectionPolicyBuilder>, ISectionPolicy> conditionBuilder)
        {
            var conditionSectionBuilder = new BackendConditionSectionBuilder();
            return AddPolicyDefinition(conditionBuilder.Invoke(conditionSectionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool firstFastRetry = false)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, string count, TimeSpan interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool firstFastRetry = false)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, string count, string interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool firstFastRetry = false)
        {
            var actionBuilder = new BackendSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder Retry(string condition, int count, string interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool firstFastRetry = false)
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

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder ForwardRequest(TimeSpan? timeout)
        {
            return AddPolicyDefinition(new ForwardRequest(timeout));
        }
    }
}