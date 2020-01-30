using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders
{
    public class DummyPolicyBuilder : IPolicyBuilder, IInboundPolicyBuilder, IBackendPolicyBuilder, IOutboundPolicyBuilder, IOnErrorPolicyBuilder, IPolicyBuilderTerminator
    {
        public TReturn Return<TReturn>()
        {
            return default(TReturn);
        }

        public IBackendPolicyBuilder Inbound(Func<IInboundSectionPolicyBuilder, ISectionPolicy> buildInboundSection)
        {
            return this;
        }

        public IOutboundPolicyBuilder Backend(Func<IBackendSectionPolicyBuilder, ISectionPolicy> buildBackendSection)
        {
            return this;
        }

        public IOnErrorPolicyBuilder Outbound(Func<IOutboundSectionPolicyBuilder, ISectionPolicy> buildOutboundSection)
        {
            return this;
        }

        public IPolicyBuilderTerminator OnError(Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> buildOnErrorSection)
        {
            return this;
        }
    }

}
