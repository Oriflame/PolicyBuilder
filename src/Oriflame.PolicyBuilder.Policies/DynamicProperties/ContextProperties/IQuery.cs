namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IQuery : IContextProperty, IBuilderReadOnlyDictionary<IQueryParam>, IGetWithDefault<IQueryParam>
    {
        IQueryParam Get(string paramName);
    }
}