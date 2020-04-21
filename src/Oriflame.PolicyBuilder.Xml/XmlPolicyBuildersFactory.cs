using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml
{
    public class XmlPolicyBuildersFactory : IBuildersFactory<XmlOperationPolicy>
    {
        public virtual IInboundSectionPolicyBuilder CreateInboundBuilder(XmlOperationPolicy xmlOperationPolicy)
        {
            return new InboundSectionPolicyBuilder(xmlOperationPolicy.InboundPolicy);
        }

        public virtual IBackendSectionPolicyBuilder CreateBackendBuilder(XmlOperationPolicy xmlOperationPolicy)
        {
            return new BackendSectionPolicyBuilder(xmlOperationPolicy.BackendPolicy);
        }

        public virtual IOutboundSectionPolicyBuilder CreateOutboundBuilder(XmlOperationPolicy xmlOperationPolicy)
        {
            return new OutboundSectionPolicyBuilder(xmlOperationPolicy.OutboundPolicy);
        }

        public virtual IOnErrorSectionPolicyBuilder CreateOnErrorBuilder(XmlOperationPolicy xmlOperationPolicy)
        {
            return new OnErrorSectionPolicyBuilderBase(xmlOperationPolicy.OnErrorPolicy);
        }

        public virtual XmlOperationPolicy CreateOperationPolicy()
        {
            return new XmlOperationPolicy();
        }
    }

}