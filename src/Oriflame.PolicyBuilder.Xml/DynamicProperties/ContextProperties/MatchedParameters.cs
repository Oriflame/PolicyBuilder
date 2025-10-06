using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    /// <summary>
    /// Original type is derived from <see cref="System.Collections.Generic.IReadOnlyDictionary{string, string}"/>
    /// </summary>
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
