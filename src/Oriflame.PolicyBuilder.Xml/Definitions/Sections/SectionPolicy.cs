using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Sections
{
    public class SectionPolicy : PolicyXmlBase, ISectionPolicy
    {
        protected readonly IList<IXmlPolicy> Policies = new List<IXmlPolicy>();
        
        public virtual void AddInnerPolicy(IXmlPolicy policy)
        {
            // Some tests can be done here i.e. policy already added
            Policies.Add(policy);
        }
        
        public override XNode GetXml()
        {
            return CreateElement(Policies.Select(p => p.GetXml()));
        }

        public SectionPolicy(string xmlNodeName, IDictionary<string, string> attributes) : base(xmlNodeName, attributes)
        {
        }

        public SectionPolicy(string xmlNodeName) : base(xmlNodeName)
        {
        }

        public virtual void AddInnerPolicy(IPolicy policy)
        {
            AddInnerPolicy(policy as IXmlPolicy);
        }
    }
}