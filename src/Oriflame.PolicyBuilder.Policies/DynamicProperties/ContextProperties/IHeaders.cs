namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IHeaders : IContextProperty, IBuilderReadOnlyDictionary<IHeader>, IGetWithDefault<IHeader>
    {
        IHeader Get(string paramName);
    }
}