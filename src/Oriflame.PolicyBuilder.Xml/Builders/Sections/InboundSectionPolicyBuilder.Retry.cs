using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(string condition, string count, TimeSpan interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(string condition, int count, string interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            string firstFastRetry)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(string condition, string count, string interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            string firstFastRetry)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder Retry(string condition, string count, string interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }
    }
}
