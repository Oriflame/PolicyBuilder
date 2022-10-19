using System.Net;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes
{
    public class CacheStoreOptionalAttributesBuilder : AttributesBuilderBase<ICacheStoreOptionalAttributesBuilder>, ICacheStoreOptionalAttributesBuilder
    {
        public ICacheStoreOptionalAttributesBuilder CacheResponse(bool value)
        {
            return AddAttribute("cache-response", value);
        }
    }
}