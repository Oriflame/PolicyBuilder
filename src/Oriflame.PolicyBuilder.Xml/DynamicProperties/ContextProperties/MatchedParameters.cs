namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class MatchedParameters : ContextProperty
    {
        public MatchedParameters(string parentPath) : base($"{parentPath}.{nameof(MatchedParameters)}")
        {
        }

        public string GetParam(string paramName)
        {
            return $"{this}[\"{paramName}\"]";
        }

        public string GetParamAsString(string paramName)
        {
            return $"(string){GetParam(paramName)}";
        }

        // TODO props
    }
}
