namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Deployment : ContextProperty
    {
        public Deployment(string path) : base(path)
        {
            Gateway = new Gateway($"{Get()}.{nameof(Gateway)}");
            Certificates = new Certificates($"{Get()}.{nameof(Certificates)}");
        }

        public Gateway Gateway;

        public string GatewayId => $"{Get()}.{nameof(Gateway)}";

        public string Region => $"{Get()}.{nameof(Region)}";

        public string ServiceId => $"{Get()}.{nameof(ServiceId)}";

        public string ServiceName => $"{Get()}.{nameof(ServiceName)}";

        //TODO IReadOnlyDictionary<string, X509Certificate2>
        public Certificates Certificates;
    }
}