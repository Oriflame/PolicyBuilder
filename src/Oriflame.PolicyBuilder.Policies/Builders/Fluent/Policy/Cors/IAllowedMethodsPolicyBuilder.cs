using System.Net.Http;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy.Cors
{
    public interface IAllowedMethodsPolicyBuilder
    {
        IAllowedMethodsPolicyBuilder PreflightResultMaxAge(int seconds);

        IAllowedHeadersPolicyBuilder AllMethods();

        IAllowedHeadersPolicyBuilder Methods(params HttpMethod[] methods);
    }
}