using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public class OnErrorSectionPolicyBuilderBase : SectionBuilderBase<IOnErrorSectionPolicyBuilder>,
        IOnErrorSectionPolicyBuilder
    {
        public OnErrorSectionPolicyBuilderBase(DependenciesPolicy operationPolicy) : base(operationPolicy)
        {
        }
    }
}