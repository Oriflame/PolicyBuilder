namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IQuery : IContextProperty
    {
        string GetParam(string paramName, string defaultValue = null);
    }
}