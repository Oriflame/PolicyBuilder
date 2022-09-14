namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes
{
    public interface ITraceAttributesBuilder : IAttributesBuilder
    {
        ITraceAttributesBuilder Source(string source);

        ITraceAttributesBuilder Severity(Severity severity);
    }
}
