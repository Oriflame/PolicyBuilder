using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class SetBody : PolicyXmlBase
    {
        private readonly string _value;

        public SetBody(string value) : base("set-body")
        {
            _value = value;
        }

        public override XNode GetXml()
        {
            return CreateElement(_value);
        }
    }
}