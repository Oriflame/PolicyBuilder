using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy.Cors
{
    public interface IExposeHeadersPolicyBuilder
    {
        ISectionPolicy AllExposeHeaders();

        ISectionPolicy ExposeHeaders(params string[] exposeHeaders);
    }
}