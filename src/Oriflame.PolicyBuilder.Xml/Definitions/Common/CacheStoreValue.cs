using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Extensions;
using Oriflame.PolicyBuilder.Xml.Extensions.Cache;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class CacheStoreValue : PolicyXmlBase
    {
        public CacheStoreValue(string key, string value, TimeSpan duration, CachingType? cachingType = null) : base("cache-store-value")
        {
            Attributes.Add("key", key);
            Attributes.Add("value", value);
            Attributes.Add("duration", duration.GetSeconds());
            if (cachingType.HasValue)
            {
                Attributes.Add("caching-type", cachingType.Value.ToXmlString());
            }
        }
    }
}