using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class BasePolicy : PolicyXmlBase
    {
        public BasePolicy() : base("base")
        {
        }

        public override XNode GetXml()
        {
            return CreateElement();
        }
    }
}