using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Extensions.Cache;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class CacheLookupValuePolicy : PolicyXmlBase
    {
        public CacheLookupValuePolicy(string key, string variable, CachingType? cachingType = null) : base("cache-lookup-value")
        {
            Attributes.Add("key", key);
            Attributes.Add("variable-name", variable);
            if (cachingType.HasValue)
            {
                Attributes.Add("caching-type", cachingType.Value.ToXmlString());
            }
        }
    }
}