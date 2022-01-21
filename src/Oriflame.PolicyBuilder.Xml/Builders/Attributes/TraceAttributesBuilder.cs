using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes
{
    public class TraceAttributesBuilder : AttributesBuilderBase<ITraceAttributesBuilder>, ITraceAttributesBuilder
    {
        public ITraceAttributesBuilder Source(string source)
        {
            return AddAttribute("source", source);
        }

        public ITraceAttributesBuilder Severity(Severity severity)
        {
            return AddAttribute("severity", severity.ToString().ToLower());
        }
    }
}