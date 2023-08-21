namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IDeployment : IContextProperty
    {
        IGateway Gateway { get; }
        string GatewayId { get; }
        string Region { get; }
        string ServiceId { get; }
        string ServiceName { get; }
        ICertificates Certificates { get; }
    }
}