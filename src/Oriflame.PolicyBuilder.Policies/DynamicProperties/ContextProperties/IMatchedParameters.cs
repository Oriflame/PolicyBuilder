namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IMatchedParameters : IContextProperty
    {
        string GetParam(string paramName);
        string GetParamAsString(string paramName);
    }
}