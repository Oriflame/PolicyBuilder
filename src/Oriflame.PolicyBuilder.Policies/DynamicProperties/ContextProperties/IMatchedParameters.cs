namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IMatchedParameters : IContextProperty, IBuilderReadOnlyDictionary<IMatchedParameter>
    {
        IMatchedParameter Get(string paramName);
    }
}
