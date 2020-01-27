using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner.Cors
{
    public class AllowedHeaders : PolicyXmlBase
    {
        private readonly IList<Header> _headers = new List<Header>();

        public AllowedHeaders() : this(new []{ "*" })
        {
        }

        public AllowedHeaders(IEnumerable<string> headerNames) : base("allowed-headers")
        {
            foreach (var headerName in headerNames)
            {
                _headers.Add(new Header(headerName));
            }
        }

        public override XNode GetXml()
        {
            return CreateElement(_headers.Select(o => (object)o.GetXml()).ToArray());
        }
    }
}