namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Operation : ContextProperty
    {
        public Operation(string path) : base(path)
        {
        }

        public string Id => $"{Get()}.{nameof(Id)}";

        public string Method => $"{Get()}.{nameof(Method)}";

        public string Name => $"{Get()}.{nameof(Name)}";

        public string UrlTemplate => $"{Get()}.{nameof(UrlTemplate)}";
    }
}