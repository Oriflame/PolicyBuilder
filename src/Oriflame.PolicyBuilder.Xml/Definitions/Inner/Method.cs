using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Method : PolicyXmlBase
    {
        private readonly string _method;

        public Method(string httpMethod) : base("method")
        {
            _method = httpMethod;
        }

        public override XNode GetXml()
        {
            return CreateElement(_method);
        }
    }
}