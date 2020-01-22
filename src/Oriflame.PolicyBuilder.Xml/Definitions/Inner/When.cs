using System.Linq;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class When : SectionPolicy
    {
        public When(string condition) : base("when")
        {
            Attributes.Add("condition", condition);
        }

        public override XNode GetXml()
        {
            return CreateElement(Policies.Select(p => p.GetXml()));
        }
    }
}