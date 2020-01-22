using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Issuers : PolicyXmlBase
    {
        private IEnumerable<Issuer> _issuers;

        public Issuers(IEnumerable<string> issuers) : base("issuers")
        {
            _issuers = issuers.Select(i => new Issuer(i));
        }

        public override XNode GetXml()
        {
            return CreateElement(_issuers.Select(i => (object)i.GetXml()).ToArray());
        }
    }
}