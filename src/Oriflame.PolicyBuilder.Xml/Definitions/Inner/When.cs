using System.Linq;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class When : SectionPolicy
    {
        // TODO : Add support for expressions
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