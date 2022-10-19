using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class CacheStore : PolicyXmlBase 
    {
        public CacheStore(TimeSpan cacheDuration) : this(cacheDuration.GetSeconds(), null)
        {
        }

        public CacheStore(string cacheDuration, IDictionary<string, string> attributes = null) : base("cache-store", attributes)
        {
            Attributes.Add("duration", cacheDuration);
        }
    }
}