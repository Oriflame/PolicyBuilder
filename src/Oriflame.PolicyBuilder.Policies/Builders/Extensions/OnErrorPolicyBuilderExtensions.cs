using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class OnErrorPolicyBuilderExtensions
    {
        public static IPolicyBuilderTerminator OnError(this IOnErrorPolicyBuilder onErrorPolicyBuilder)
        {
            return onErrorPolicyBuilder
                .OnError(builder => builder
                    .Base()
                    .Create()
                );
        }
    }
}