using System.Net.Http;
using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class SetMethod : PolicyXmlBase
    {
        private readonly HttpMethod _httpMethod;

        public SetMethod(HttpMethod httpMethod) : base("set-method")
        {
            _httpMethod = httpMethod;
        }

        public override XNode GetXml()
        {
            return CreateElement(_httpMethod.Method);
        }
    }
}