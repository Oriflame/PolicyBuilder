using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Value : PolicyXmlBase
    {
        private readonly string _value;

        public Value(string value) : base("value")
        {
            _value = value;
        }

        public override XNode GetXml()
        {
            return CreateElement(_value);
        }
    }
}
