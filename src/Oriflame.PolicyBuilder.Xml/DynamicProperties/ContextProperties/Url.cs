using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Url : ContextProperty, IUrl
    {
        public Url(string path) : base(path)
        {
            Query = new Query($"{Get()}.{nameof(Query)}");
        }

        public string Host => $"{Get()}.{nameof(Host)}";

        public string Path => $"{Get()}.{nameof(Path)}";

        public string Port => $"{Get()}.{nameof(Port)}";

        public IQuery Query { get; }

        public string QueryString => $"{Get()}.{nameof(QueryString)}";

        public string Scheme => $"{Get()}.{nameof(Scheme)}";
    }
}
