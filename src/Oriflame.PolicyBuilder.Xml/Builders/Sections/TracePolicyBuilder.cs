using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner.Trace;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class TracePolicyBuilder : SectionBuilderBase<ITracePolicyBuilder>, ITracePolicyBuilder
    {
        public TracePolicyBuilder(IDictionary<string, string> attributes) : base(new SectionPolicy("trace", attributes))
        {
        }

        public ITracePolicyBuilder Message(string message)
        {
            return AddPolicyDefinition(new Message(message));
        }

        public ITracePolicyBuilder Metadata(string name, string value)
        {
            return AddPolicyDefinition(new Metadata(name, value));
        }
    }
}
