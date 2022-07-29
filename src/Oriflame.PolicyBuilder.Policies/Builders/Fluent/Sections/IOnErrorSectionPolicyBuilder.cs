using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IOnErrorSectionPolicyBuilder : IPolicySectionBuilder<IOnErrorSectionPolicyBuilder>, IRetry<IOnErrorSectionPolicyBuilder>
    {
    }
}