using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Issuer : PolicyXmlBase
    {
        private string _issuerName;

        public Issuer(string issuerName) : base("issuer")
        {
            _issuerName = issuerName;
        }

        public override XNode GetXml()
        {
            return CreateElement(_issuerName);
        }
    }
}