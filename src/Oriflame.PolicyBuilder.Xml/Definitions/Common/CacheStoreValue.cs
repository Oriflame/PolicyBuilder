using System;
using Oriflame.PolicyBuilder.Xml.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class CacheStoreValue : PolicyXmlBase
    {
        public CacheStoreValue(string key, string value, TimeSpan duration) : base("cache-store-value")
        {
            Attributes.Add("key", key);
            Attributes.Add("value", value);
            Attributes.Add("duration", duration.GetSeconds());
        }
    }
}