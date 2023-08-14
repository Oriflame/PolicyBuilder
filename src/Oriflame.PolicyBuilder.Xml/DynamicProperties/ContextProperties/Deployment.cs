using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Deployment : ContextProperty, IDeployment
    {
        public Deployment(string path) : base(path)
        {
            Gateway = new Gateway($"{GetPropertyPath()}.{nameof(Gateway)}");
            Certificates = new Certificates($"{GetPropertyPath()}.{nameof(Certificates)}");
        }

        public IGateway Gateway { get; }

        public string GatewayId => $"{GetPropertyPath()}.{nameof(Gateway)}";

        public string Region => $"{GetPropertyPath()}.{nameof(Region)}";

        public string ServiceId => $"{GetPropertyPath()}.{nameof(ServiceId)}";

        public string ServiceName => $"{GetPropertyPath()}.{nameof(ServiceName)}";

        //TODO IReadOnlyDictionary<string, X509Certificate2>
        public ICertificates Certificates { get; }
    }
}