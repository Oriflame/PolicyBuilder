using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy.Cors;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy
{
    public interface ICorsPolicySectionBuilder : IPolicySectionBuilder, IAllowedOriginsPolicyBuilder
    {
    }
}