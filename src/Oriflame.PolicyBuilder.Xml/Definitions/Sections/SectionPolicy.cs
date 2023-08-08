using System.Collections.Generic;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Collections;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Sections
{
    public class SectionPolicy : PolicyXmlBase, ISectionPolicy
    {
        protected readonly StalePriorityQueue<IXmlPolicy, int> Policies = new();
        
        public virtual void AddInnerPolicy(IXmlPolicy policy)
        {
            // Some tests can be done here i.e. policy already added
            Policies.Enqueue(policy, 0);
        }
        public virtual void AddInnerPolicy(IXmlPolicy policy, int priority)
        {
            // Some tests can be done here i.e. policy already added
            Policies.Enqueue(policy, priority);
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

        public virtual void AddInnerPolicy(IPolicy policy, int priority)
        {
            AddInnerPolicy(policy as IXmlPolicy, priority);
        }
    }
}