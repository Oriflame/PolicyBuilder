namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy.Cors
{
    public interface IAllowedOriginsPolicyBuilder
    {
        IAllowedMethodsPolicyBuilder AllOrigins();

        IAllowedMethodsPolicyBuilder Origins(params string[] origins);
    }
}