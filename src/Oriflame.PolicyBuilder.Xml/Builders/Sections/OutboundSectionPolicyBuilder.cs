using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class OutboundSectionPolicyBuilder : SectionBuilderBase<IOutboundSectionPolicyBuilder>, IOutboundSectionPolicyBuilder
    {
        public OutboundSectionPolicyBuilder(ISectionPolicy sectionPolicy) : base(sectionPolicy)
        {
        }

        /// <inheritdoc />
        public virtual IOutboundSectionPolicyBuilder SetBody(ILiquidTemplate template)
        {
            return AddPolicyDefinition(new SetBodyLiquid(template));
        }

        /// <inheritdoc />
        public virtual IOutboundSectionPolicyBuilder SetBody(string content)
        {
            return AddPolicyDefinition(new SetBody(content));
        }

        public override IOutboundSectionPolicyBuilder Choose(Func<IConditionSectionBuilder<IOutboundSectionPolicyBuilder>, ISectionPolicy> conditionBuilder)
        {
            var conditionSectionBuilder = new OutboundConditionSectionBuilder();
            return AddPolicyDefinition(conditionBuilder.Invoke(conditionSectionBuilder));
        }

        /// <inheritdoc />
        public virtual IOutboundSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IOutboundSectionPolicyBuilder, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            var actionBuilder = new OutboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        public virtual IOutboundSectionPolicyBuilder SetStatus(string statusCode, string reason)
        {
            return AddPolicyDefinition(new SetStatus(statusCode, reason));
        }
    }
}