using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml
{
    public class XmlPolicyBuildersFactory : IBuildersFactory<XmlOperationPolicy>
    {
        public IInboundSectionPolicyBuilder CreateInboundBuilder(XmlOperationPolicy xmlOperationPolicy)
        {
            return new InboundSectionPolicyBuilder(xmlOperationPolicy.InboundPolicy);
        }

        public IBackendSectionPolicyBuilder CreateBackendBuilder(XmlOperationPolicy xmlOperationPolicy)
        {
            return new BackendSectionPolicyBuilder(xmlOperationPolicy.BackendPolicy);
        }

        public IOutboundSectionPolicyBuilder CreateOutboundBuilder(XmlOperationPolicy xmlOperationPolicy)
        {
            return new OutboundSectionPolicyBuilder(xmlOperationPolicy.OutboundPolicy);
        }

        public IOnErrorSectionPolicyBuilder CreateOnErrorBuilder(XmlOperationPolicy xmlOperationPolicy)
        {
            return new OnErrorSectionPolicyBuilderBase(xmlOperationPolicy.OnErrorPolicy);
        }

        public XmlOperationPolicy CreateOperationPolicy()
        {
            return new XmlOperationPolicy();
        }
    }

}