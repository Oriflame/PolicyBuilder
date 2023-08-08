using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Oriflame.PolicyBuilder.Xml.Enums;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class SendRequestSectionBuilder : SectionBuilderBase<ISendRequestSectionBuilder>, ISendRequestSectionBuilder
    {
        public SendRequestSectionBuilder(IDictionary<string, string> attributes) : base(new SectionPolicy("send-request", attributes))
        {
        }

        public virtual ISendRequestSectionBuilder SetUrl(string url)
        {
            return AddPolicyDefinition(new SetUrl(url), Priority.SetUrl);
        }

        public virtual ISendRequestSectionBuilder SetBody(string content)
        {
            return AddPolicyDefinition(new SetBody(content), Priority.SetBody);
        }

        public ISendRequestSectionBuilder AuthenticationCertificate(string thumbprint)
        {
            return AddPolicyDefinition(new AuthenticationCertificate(thumbprint), Priority.AuthenticationCertificate);
        }
    }
}