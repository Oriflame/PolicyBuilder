namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IHeaders : IContextProperty
    {
        string GetParam(string paramName, string defaultValue = null);
    }
}