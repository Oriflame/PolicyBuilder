using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class SetUrl : PolicyXmlBase
    {
        private readonly string _value;

        public SetUrl(string value) : base("set-url")
        {
            _value = value;
        }

        public override XNode GetXml()
        {
            return CreateElement(_value);
        }
    }
}