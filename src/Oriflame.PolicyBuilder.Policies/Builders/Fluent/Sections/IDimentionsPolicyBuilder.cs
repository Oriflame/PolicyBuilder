namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IEmitMetricPolicyBuilder : IPolicySectionBuilder
    {
        IEmitMetricPolicyBuilder SetDimention(string name, string value);
    }
}
