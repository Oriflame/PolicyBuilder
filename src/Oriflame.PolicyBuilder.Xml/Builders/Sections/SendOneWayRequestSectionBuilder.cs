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
    public class SendOneWayRequestSectionBuilder : SectionBuilderBase<ISendOneWayRequestSectionBuilder>, ISendOneWayRequestSectionBuilder
    {
        public SendOneWayRequestSectionBuilder(IDictionary<string, string> attributes) : base(new SectionPolicy("send-one-way-request", attributes))
        {
        }

        public virtual ISendOneWayRequestSectionBuilder SetUrl(string url)
        {
            return AddPolicyDefinition(new SetUrl(url), (int)SendRequestPriority.SetUrl);
        }

        public virtual ISendOneWayRequestSectionBuilder SetMethod(HttpMethod httpMethod)
        {
            return AddPolicyDefinition(new SetMethod(httpMethod), (int)SendRequestPriority.SetMethod);
        }

        public virtual ISendOneWayRequestSectionBuilder SetBody(string content)
        {
            return AddPolicyDefinition(new SetBody(content), (int)SendRequestPriority.SetBody);
        }

        public virtual ISendOneWayRequestSectionBuilder SetHeader(string name, string value, ExistsAction? existsAction)
        {
            return AddPolicyDefinition(new SetHeader(name, value, existsAction), (int)SendRequestPriority.SetHeader);
        }

        public ISendOneWayRequestSectionBuilder AuthenticationCertificate(string thumbprint)
        {
            return AddPolicyDefinition(new AuthenticationCertificate(thumbprint), (int)SendRequestPriority.AuthenticationCertificate);
        }
    }
}