using System;
using Oriflame.PolicyBuilder.Policies.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class CacheStore : PolicyXmlBase 
    {
        public CacheStore(TimeSpan cacheDuration) : this(cacheDuration.GetSeconds())
        {
        }
        
        public CacheStore(string cacheDuration) : base("cache-store")
        {
            Attributes.Add("duration", cacheDuration);
        }
    }
}