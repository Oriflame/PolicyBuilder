using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class SendRequestSectionBuilder : SectionBuilderBase<ISendRequestSectionBuilder>, ISendRequestSectionBuilder
    {
        public SendRequestSectionBuilder(IDictionary<string, string> attributes) : base(new SectionPolicy("send-request", attributes))
        {
        }

        public ISendRequestSectionBuilder SetUrl(string url)
        {
            return AddPolicyDefinition(new SetUrl(url));
        }

        public ISendRequestSectionBuilder SetBody(string content)
        {
            return AddPolicyDefinition(new SetBody(content));
        }
    }
}