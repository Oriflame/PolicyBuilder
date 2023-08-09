using System.Collections.Generic;
using System.Net.Http;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Oriflame.PolicyBuilder.Xml.Enums.Priorities;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class SendRequestSectionBuilder : SectionBuilderBase<ISendRequestSectionBuilder>, ISendRequestSectionBuilder
    {
        public SendRequestSectionBuilder(IDictionary<string, string> attributes) : base(new SectionPolicy("send-request", attributes))
        {
        }

        public virtual ISendRequestSectionBuilder SetUrl(string url)
        {
            return AddPolicyDefinition(new SetUrl(url), (int)SendRequestPriority.SetUrl);
        }

        public virtual ISendRequestSectionBuilder SetMethod(HttpMethod httpMethod)
        {
            return AddPolicyDefinition(new SetMethod(httpMethod), (int)SendRequestPriority.SetMethod);
        }

        public virtual ISendRequestSectionBuilder SetBody(string content)
        {
            return AddPolicyDefinition(new SetBody(content), (int)SendRequestPriority.SetBody);
        }

        public virtual ISendRequestSectionBuilder SetHeader(string name, string value, ExistsAction? existsAction)
        {
            return AddPolicyDefinition(new SetHeader(name, value, existsAction), (int)SendRequestPriority.SetHeader);
        }

        public ISendRequestSectionBuilder AuthenticationCertificate(string thumbprint)
        {
            return AddPolicyDefinition(new AuthenticationCertificate(thumbprint), (int)SendRequestPriority.AuthenticationCertificate);
        }
    }
}