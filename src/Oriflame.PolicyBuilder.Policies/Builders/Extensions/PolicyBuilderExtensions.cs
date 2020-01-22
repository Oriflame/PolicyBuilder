using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class PolicyBuilderExtensions
    {
        public static IPolicyBuilderTerminator RewriteUri(this IPolicyBuilder policyBuilder, string uri)
        {
            return policyBuilder
                .Inbound(builder => builder.BaseWithRewriteUri(uri))
                .Backend()
                .Outbound()
                .OnError();
        }

        public static IPolicyBuilderTerminator SetBackendService(this IPolicyBuilder policyBuilder, string domain)
        {
            return policyBuilder
                .Inbound(builder => builder
                    .Base()
                    .SetBackendService(domain)
                    .Create()
                )
                .Backend()
                .Outbound()
                .OnError();
        }

        public static IPolicyBuilderTerminator SetBackendAndRewriteUri(this IPolicyBuilder policyBuilder, string domain,
            string uri)
        {
            return policyBuilder
                .Inbound(builder => builder
                    .Base()
                    .SetBackendAndRewriteUri(domain, uri))
                .Backend()
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