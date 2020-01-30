using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Origin : PolicyXmlBase
    {
        private readonly string _origin;

        public Origin(string origin) : base("origin")
        {
            _origin = origin;
        }

        public override XNode GetXml()
        {
            return CreateElement(_origin);
        }
    }
}