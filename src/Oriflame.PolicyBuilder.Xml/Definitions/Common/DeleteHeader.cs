using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class DeleteHeader : PolicyXmlBase
    {
        public DeleteHeader(string name) : base("set-header")
        {
            Attributes.Add("name", name);
            Attributes.Add("exists-action", "delete");
        }

        public override XNode GetXml()
        {
            return CreateElement();
        }
    }
}