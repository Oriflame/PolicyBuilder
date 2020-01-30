using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class OutboundPolicyBuilderExtensions
    {
        public static IOnErrorPolicyBuilder Outbound(this IOutboundPolicyBuilder outboundPolicyBuilder)
        {
            return outboundPolicyBuilder
                .Outbound(builder => builder
                    .Base()
                    .Create()
                );
        }

        public static IOnErrorPolicyBuilder OutboundWithCaching(this IOutboundPolicyBuilder outboundPolicyBuilder, TimeSpan cacheDurationSeconds)
        {
            return outboundPolicyBuilder
                .Outbound(builder => builder
                    .Base()
                    .CacheStore(cacheDurationSeconds)
                    .Create()
                );
        }
    }
}