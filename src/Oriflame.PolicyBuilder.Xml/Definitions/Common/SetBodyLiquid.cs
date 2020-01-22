using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class SetBodyLiquid : PolicyXmlBase
    {
        private readonly ILiquidTemplate _template;

        public SetBodyLiquid(ILiquidTemplate template) : base("set-body")
        {
            _template = template;
            Attributes.Add("template", "liquid");
        }

        public override XNode GetXml()
        {
            return CreateElement(_template.GetAsString());
        }
    }
}