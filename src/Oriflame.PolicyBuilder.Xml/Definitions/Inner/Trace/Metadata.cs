using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner.Trace
{
    public class Metadata : PolicyXmlBase
    {
        public Metadata(string name, string value) : base("metadata")
        {
            Attributes.Add("name", name);
            Attributes.Add("value", value);
        }

        public override XNode GetXml()
        {
            return CreateElement();
        }
    }
}