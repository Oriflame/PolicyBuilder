using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner.Cors
{
    public class AllowedOrigins : PolicyXmlBase
    {
        private readonly IList<Origin> _origins = new List<Origin>();

        public AllowedOrigins() : this(new []{ "*" })
        {
        }

        public AllowedOrigins(string[] origins) : base("allowed-origins")
        {
            foreach (var origin in origins)
            {
                _origins.Add(new Origin(origin));
            }
        }

        public override XNode GetXml()
        {
            return CreateElement(_origins.Select(o => (object)o.GetXml()).ToArray());
        }
    }
}