namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface ISubscriptionKeyParameterNames : IContextProperty
    {
        string Header { get; }
        string Query { get; }
    }
}