using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class DeleteQueryParameter : PolicyXmlBase
    {
        public DeleteQueryParameter(string name) : base("set-query-parameter")
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