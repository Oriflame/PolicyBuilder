namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy.Cors
{
    public interface IAllowedHeadersPolicyBuilder
    {
        IExposeHeadersPolicyBuilder AllHeaders();

        IExposeHeadersPolicyBuilder Headers(params string[] headers);
    }
}