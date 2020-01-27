using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders
{
    public interface IBuildersFactory<TOperationPolicy> where TOperationPolicy : IOperationPolicy
    {
        IInboundSectionPolicyBuilder CreateInboundBuilder(TOperationPolicy operationPolicy);

        IBackendSectionPolicyBuilder CreateBackendBuilder(TOperationPolicy operationPolicy);

        IOutboundSectionPolicyBuilder CreateOutboundBuilder(TOperationPolicy operationPolicy);

        IOnErrorSectionPolicyBuilder CreateOnErrorBuilder(TOperationPolicy operationPolicy);

        TOperationPolicy CreateOperationPolicy();
    }
}