using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Xml.Extensions.Cache;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes
{
    public class CacheLookupAttributesBuilder : AttributesBuilderBase<ICacheLookupAttributesBuilder>, ICacheLookupAttributesBuilder
    {
        public ICacheLookupAttributesBuilder AllowPrivateResponseCaching(bool value)
        {
            return AddAttribute("allow-private-response-caching", value);
        }

        public ICacheLookupAttributesBuilder DownstreamCachingType(DownstreamCachingType downstreamCachingType)
        {
            return AddAttribute("downstream-caching-type", downstreamCachingType.ToString().ToLower());
        }

        public ICacheLookupAttributesBuilder MustRevalidate(bool value)
        {
            return AddAttribute("must-revalidate", value);
        }

        public ICacheLookupAttributesBuilder CachingType(CachingType cachingType)
        {
            return AddAttribute("caching-type", cachingType.ToXmlString());
        }
        
        public ICacheLookupAttributesBuilder VaryByDeveloper(bool value)
        {
            return AddAttribute("vary-by-developer", value);
        }

        public ICacheLookupAttributesBuilder VaryByDeveloperGroups(bool value)
        {
            return AddAttribute("vary-by-developer-groups", value);
        }
    }
}