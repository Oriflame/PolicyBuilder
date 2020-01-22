using Oriflame.PolicyBuilder.Dependencies.Builders;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Dependencies
{
    public class DependenciesPolicyBuildersFactory : IBuildersFactory<DependenciesPolicy>
    {
        public IInboundSectionPolicyBuilder CreateInboundBuilder(DependenciesPolicy operationPolicy)
        {
            return new InboundSectionPolicyBuilder(operationPolicy);
        }

        public IBackendSectionPolicyBuilder CreateBackendBuilder(DependenciesPolicy operationPolicy)
        {
            return new BackendSectionPolicyBuilder(operationPolicy);
        }

        public IOutboundSectionPolicyBuilder CreateOutboundBuilder(DependenciesPolicy operationPolicy)
        {
            return new OutboundSectionPolicyBuilder(operationPolicy);
        }

        public IOnErrorSectionPolicyBuilder CreateOnErrorBuilder(DependenciesPolicy operationPolicy)
        {
            return new OnErrorSectionPolicyBuilderBase(operationPolicy);
        }

        public DependenciesPolicy CreateOperationPolicy()
        {
            return new DependenciesPolicy();
        }
    }
}