using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Deployment : ContextProperty, IDeployment
    {
        public Deployment(string path) : base(path)
        {
            Gateway = new Gateway($"{Get()}.{nameof(Gateway)}");
            Certificates = new Certificates($"{Get()}.{nameof(Certificates)}");
        }

        public IGateway Gateway { get; }

        public string GatewayId => $"{Get()}.{nameof(Gateway)}";

        public string Region => $"{Get()}.{nameof(Region)}";

        public string ServiceId => $"{Get()}.{nameof(ServiceId)}";

        public string ServiceName => $"{Get()}.{nameof(ServiceName)}";

        //TODO IReadOnlyDictionary<string, X509Certificate2>
        public ICertificates Certificates { get; }
    }
}