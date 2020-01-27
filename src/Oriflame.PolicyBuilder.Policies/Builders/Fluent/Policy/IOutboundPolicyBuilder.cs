using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy
{
    public interface IOutboundPolicyBuilder
    {
        IOnErrorPolicyBuilder Outbound(Func<IOutboundSectionPolicyBuilder, ISectionPolicy> buildOutboundSection);
    }
}