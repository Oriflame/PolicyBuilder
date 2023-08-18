using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Deployment : ContextProperty, IDeployment
    {
        public Deployment(string path) : base(path)
        {
            Gateway = new Gateway(GetPropertyPath(nameof(Gateway)));
            Certificates = new Certificates(GetPropertyPath(nameof(Certificates)));
        }

        public IGateway Gateway { get; }

        public string GatewayId => GetPropertyPath(GatewayId);

        public string Region => GetPropertyPath(Region);

        public string ServiceId => GetPropertyPath(ServiceId);

        public string ServiceName => GetPropertyPath(ServiceName);

        //TODO IReadOnlyDictionary<string, X509Certificate2>
        public ICertificates Certificates { get; }
    }
}