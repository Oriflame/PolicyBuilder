using System;
using Oriflame.PolicyBuilder.Xml.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class CacheStore : PolicyXmlBase 
    {
        public CacheStore(TimeSpan cacheDuration) : base("cache-store")
        {
            Attributes.Add("duration", cacheDuration.GetSeconds());
        }
    }
}