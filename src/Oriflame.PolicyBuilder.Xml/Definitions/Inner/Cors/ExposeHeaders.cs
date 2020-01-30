using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner.Cors
{
    public class ExposeHeaders : PolicyXmlBase
    {
        private readonly IList<Header> _exposeHeaders = new List<Header>();

        public ExposeHeaders() : this(new []{ "*" })
        {
        }

        public ExposeHeaders(IEnumerable<string> exposeHeaders) : base("expose-headers")
        {
            foreach (var exposeHeader in exposeHeaders)
            {
                _exposeHeaders.Add(new Header(exposeHeader));
            }
        }

        public override XNode GetXml()
        {
            return CreateElement(_exposeHeaders.Select(o => (object)o.GetXml()).ToArray());
        }
    }
}