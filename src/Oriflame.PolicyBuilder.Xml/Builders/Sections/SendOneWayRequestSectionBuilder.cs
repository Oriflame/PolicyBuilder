using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class SendOneWayRequestSectionBuilder : SectionBuilderBase<ISendOneWayRequestSectionBuilder>, ISendOneWayRequestSectionBuilder
    {
        public SendOneWayRequestSectionBuilder(IDictionary<string, string> attributes) : base(new SectionPolicy("send-one-way-request", attributes))
        {
        }

        public virtual ISendOneWayRequestSectionBuilder SetUrl(string url)
        {
            return AddPolicyDefinitionAsFirst(new SetUrl(url));
        }

        public virtual ISendOneWayRequestSectionBuilder SetBody(string content)
        {
            return AddPolicyDefinition(new SetBody(content));
        }

        public ISendOneWayRequestSectionBuilder AuthenticationCertificate(string thumbprint)
        {
            return AddPolicyDefinition(new AuthenticationCertificate(thumbprint));
        }
    }
}