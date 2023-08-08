using System.Collections.Generic;
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
            // For each policy in Policies, call GetXml and return the result
            var nodes = new List<XNode>();
            while (!Policies.IsEmpty)
            {
                var policy = Policies.Dequeue();
                nodes.Add(policy.GetXml());
            }

            return CreateElement(nodes);
        }
    }
}