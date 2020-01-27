using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class InboundSectionPolicyBuilderExtensions
    {
        public static ISectionPolicy BaseWithRewriteUri(this IInboundSectionPolicyBuilder sectionBuilder, string uri)
        {
            return sectionBuilder
                    .Base()
                    .RewriteUri(uri)
                    .Create();
        }

        public static ISectionPolicy SetBackendAndRewriteUri(this IInboundSectionPolicyBuilder policyBuilder, string domain,
            string uri)
        {
            return policyBuilder
                .SetBackendService(domain)
                .RewriteUri(uri)
                .Create();
        }

        public static IInboundSectionPolicyBuilder CacheLookup(this IInboundSectionPolicyBuilder sectionBuilder)
        {
            return sectionBuilder
                .CacheLookup(cacheAttributesBuilder => cacheAttributesBuilder
                    .VaryByDeveloper(false)
                    .VaryByDeveloperGroups(false)
                    .AllowPrivateResponseCaching(true)
                    .Create()
                );
        }
    }
}