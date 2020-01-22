using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class InboundPolicyBuilderExtensions
    {
        public static IBackendPolicyBuilder Inbound(this IInboundPolicyBuilder inboundPolicyBuilder)
        {
            return inboundPolicyBuilder
                .Inbound(builder => builder
                    .Base()
                    .Create()
                );
        }
    }
}