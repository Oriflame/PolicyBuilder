namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface ITracePolicyBuilder : IPolicySectionBuilder
    {
        ITracePolicyBuilder Metadata(string name, string value);
    }
}
