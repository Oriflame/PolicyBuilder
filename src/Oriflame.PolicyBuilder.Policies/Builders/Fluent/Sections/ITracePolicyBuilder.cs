namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface ITracePolicyBuilder : IPolicySectionBuilder
    {
        ITracePolicyBuilder Message(string message);

        ITracePolicyBuilder Metadata(string name, string value);
    }
}
