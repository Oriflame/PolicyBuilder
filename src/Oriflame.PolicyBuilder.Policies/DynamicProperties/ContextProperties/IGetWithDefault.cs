namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IGetWithDefault<T> : IContextProperty
    {
        T GetValueOrDefault(string paramName, string defaultValue = null);
    }
}
