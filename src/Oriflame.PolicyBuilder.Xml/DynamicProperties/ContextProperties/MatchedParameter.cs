using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class MatchedParameter : ContextProperty, IMatchedParameter
    {
        public MatchedParameter(string path) : base(path)
        {
        }

        public string AsString()
        {
            return $"(string){GetPropertyPath()}";
        }

        // TODO props
    }
}
