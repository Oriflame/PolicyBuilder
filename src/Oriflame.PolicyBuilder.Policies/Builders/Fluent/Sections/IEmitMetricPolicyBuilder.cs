namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IEmitMetricPolicyBuilder : IPolicySectionBuilder
    {
        IEmitMetricPolicyBuilder Dimension(string name, string value = null);
    }
}
