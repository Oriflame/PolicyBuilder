using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class PolicyBuilderExtensions
    {
        public static IPolicyBuilderTerminator RewriteUri(this IPolicyBuilder policyBuilder, string uri)
        {
            return policyBuilder.RewriteUri(uri, b => b.Backend());
        }

        public static IPolicyBuilderTerminator RewriteUri(this IPolicyBuilder policyBuilder, string uri, Func<IBackendPolicyBuilder, IOutboundPolicyBuilder> buildBackendSection)
        {
            var backendPolicyBuilder = policyBuilder
                .Inbound(builder => builder.BaseWithRewriteUri(uri));

            var outboundPolicyBuilder = buildBackendSection.Invoke(backendPolicyBuilder);

            return outboundPolicyBuilder
                .Outbound()
                .OnError();
        }

        public static IPolicyBuilderTerminator SetBackendService(this IPolicyBuilder policyBuilder, string domain)
        {
            return policyBuilder.SetBackendService(domain, b => b.Backend());
        }

        public static IPolicyBuilderTerminator SetBackendService(this IPolicyBuilder policyBuilder, string domain, Func<IBackendPolicyBuilder, IOutboundPolicyBuilder> buildBackendSection)
        {
            var backendPolicyBuilder = policyBuilder
                .Inbound(builder => builder
                    .Base()
                    .SetBackendService(domain)
                    .Create()
                );

            var outboundPolicyBuilder = buildBackendSection.Invoke(backendPolicyBuilder);

            return outboundPolicyBuilder
                .Outbound()
                .OnError();
        }

        public static IPolicyBuilderTerminator SetBackendAndRewriteUri(this IPolicyBuilder policyBuilder, string domain,
            string uri)
        {
            return policyBuilder.SetBackendAndRewriteUri(domain, uri, b => b.Backend());
        }

        public static IPolicyBuilderTerminator SetBackendAndRewriteUri(this IPolicyBuilder policyBuilder, string domain,
            string uri, Func<IBackendPolicyBuilder, IOutboundPolicyBuilder> buildBackendSection)
        {
            var backendPolicyBuilder = policyBuilder
                .Inbound(builder => builder
                    .Base()
                    .SetBackendAndRewriteUri(domain, uri));

            var outboundPolicyBuilder = buildBackendSection.Invoke(backendPolicyBuilder);
                
            return outboundPolicyBuilder
                .Outbound()
                .OnError();
        }

        public static IPolicyBuilderTerminator UseDefaultPolicy(this IPolicyBuilder policyBuilder)
        {
            return policyBuilder
                .Inbound()
                .Backend()
                .Outbound()
                .OnError();
        }

        public static IPolicyBuilderTerminator UseFile(this IPolicyBuilder policyBuilder)
        {
            return policyBuilder
                .Inbound()
                .Backend()
                .Outbound()
                .OnError();
        }
    }
}