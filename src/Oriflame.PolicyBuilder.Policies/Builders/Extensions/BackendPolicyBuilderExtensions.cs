using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class BackendPolicyBuilderExtensions
    {
        public static IOutboundPolicyBuilder Backend(this IBackendPolicyBuilder backendPolicyBuilder)
        {
            return backendPolicyBuilder
                .Backend(builder => builder
                    .Base()
                    .Create()
                );
        }
    }
}