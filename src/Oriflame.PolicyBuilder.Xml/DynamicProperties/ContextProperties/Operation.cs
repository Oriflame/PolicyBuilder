using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Operation : ContextProperty, IOperation
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