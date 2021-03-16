using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes
{
    public class CorsAttributesBuilder : AttributesBuilderBase<CorsAttributesBuilder>, ICorsAttributesBuilder
    {
        public ICorsAttributesBuilder AllowCredentials(bool value)
        {
            return AddAttribute("allow-credentials", value);
        }

        public ICorsAttributesBuilder TerminateUnmatchedRequest(bool value)
        {
            return AddAttribute("terminate-unmatched-request", value);
        }
    }
}