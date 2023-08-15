using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class MatchedParameter : ContextProperty, IMatchedParameter
    {
        public MatchedParameter(string path) : base(path)
        {
        }
    }
}
