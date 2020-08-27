using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class VaryByQueryParameter : PolicyXmlBase
    {
        private readonly string _value;

        public VaryByQueryParameter(string value) : base("vary-by-query-parameter")
        {
            _value = value;
        }

        public override XNode GetXml()
        {
            return CreateElement(_value);
        }
    }
}
