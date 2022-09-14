namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes
{
    public interface IEmitMetricAttributesBuilder : IAttributesBuilder
    {
        IEmitMetricAttributesBuilder Name(string name);

        IEmitMetricAttributesBuilder Value(string value);

        IEmitMetricAttributesBuilder Namespace(string @namespace);
    }
}
