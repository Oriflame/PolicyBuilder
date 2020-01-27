using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class CacheLookupPolicy : PolicyXmlBase
    {
        public CacheLookupPolicy(IDictionary<string, string> attributes) : base("cache-lookup", attributes)
        {
        }
    }
}