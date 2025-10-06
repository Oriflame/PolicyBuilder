using System.Collections.Generic;
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
    }
}