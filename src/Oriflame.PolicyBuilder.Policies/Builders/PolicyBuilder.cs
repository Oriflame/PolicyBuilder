using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders
{
    public class PolicyBuilder : IPolicyBuilder, IInboundPolicyBuilder, IBackendPolicyBuilder, IOutboundPolicyBuilder, IOnErrorPolicyBuilder, IPolicyBuilderTerminator
    {
        private readonly IInboundSectionPolicyBuilder _inboundSectionPolicyBuilder;

        private readonly IBackendSectionPolicyBuilder _backendSectionPolicyBuilder;

        private readonly IOutboundSectionPolicyBuilder _outboundSectionPolicyBuilder;

        private readonly IOnErrorSectionPolicyBuilder _onErrorSectionPolicyBuilder;

        private readonly IOperationPolicy _operationPolicy;

        public PolicyBuilder(
            IInboundSectionPolicyBuilder inboundSectionPolicyBuilder, 
            IBackendSectionPolicyBuilder backendSectionPolicyBuilder,
            IOutboundSectionPolicyBuilder outboundSectionPolicyBuilder,
            IOnErrorSectionPolicyBuilder onErrorSectionPolicyBuilder,
            IOperationPolicy operationPolicy)
        {
            _inboundSectionPolicyBuilder = inboundSectionPolicyBuilder;
            _backendSectionPolicyBuilder = backendSectionPolicyBuilder;
            _outboundSectionPolicyBuilder = outboundSectionPolicyBuilder;
            _onErrorSectionPolicyBuilder = onErrorSectionPolicyBuilder;
            _operationPolicy = operationPolicy;
        }

        public IBackendPolicyBuilder Inbound(Func<IInboundSectionPolicyBuilder, ISectionPolicy> buildInboundSection)
        {
            buildInboundSection.Invoke(_inboundSectionPolicyBuilder);
            return this;
        }

        public IOutboundPolicyBuilder Backend(Func<IBackendSectionPolicyBuilder, ISectionPolicy> buildBackendSection)
        {
            buildBackendSection.Invoke(_backendSectionPolicyBuilder);
            return this;
        }

        public IOnErrorPolicyBuilder Outbound(Func<IOutboundSectionPolicyBuilder, ISectionPolicy> buildOutboundSection)
        {
           buildOutboundSection.Invoke(_outboundSectionPolicyBuilder);
            return this;
        }

        public IPolicyBuilderTerminator OnError(Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> buildOnErrorSection)
        {
            buildOnErrorSection.Invoke(_onErrorSectionPolicyBuilder);
            return this;
        }
        
        public TReturn Return<TReturn>()
        {
            return default(TReturn);
        }
    }

}
