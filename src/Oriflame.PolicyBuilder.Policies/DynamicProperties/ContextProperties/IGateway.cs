namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IGateway : IContextProperty
    {
        string Id { get; }
        string InstanceId { get; }
        string IsManaged { get; }
    }
}