namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IGetWithDefault<T>
    {
        T GetValueOrDefault(string paramName, string defaultValue = null);
    }
}
