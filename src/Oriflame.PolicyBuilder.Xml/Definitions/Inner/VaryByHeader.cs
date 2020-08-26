using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class VaryByHeader : PolicyXmlBase
    {
        private readonly string _value;

        public VaryByHeader(string value) : base("vary-by-header")
        {
            _value = value;
        }

        public override XNode GetXml()
        {
            return CreateElement(_value);
        }
    }
}
