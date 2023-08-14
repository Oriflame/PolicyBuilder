using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class MatchedParameters : ReadonlyDictionaryContextProperty<IMatchedParameter>, IMatchedParameters
    {
        public MatchedParameters(string path) : base(path)
        {
        }

        protected override IMatchedParameter CreateInstance(string propertyPath)
        {
            return new MatchedParameter(propertyPath);
        }
    }
}
