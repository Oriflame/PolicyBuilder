using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Header : PolicyXmlBase
    {
        private readonly string _value;

        public Header(string value) : base("header")
        {
            _value = value;
        }

        public override XNode GetXml()
        {
            return CreateElement(_value);
        }
    }
}