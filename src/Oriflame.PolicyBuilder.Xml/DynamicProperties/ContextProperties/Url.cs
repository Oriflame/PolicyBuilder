namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Url : ContextProperty
    {
        public Url(string path) : base(path)
        {
        }

        public string Host => $"{Get()}.{nameof(Host)}";

        public string Path => $"{Get()}.{nameof(Path)}";

        public string Port => $"{Get()}.{nameof(Port)}";

        public Query Query => new Query($"{Get()}.{nameof(Query)}");

        public string QueryString => $"{Get()}.{nameof(QueryString)}";

        public string Scheme => $"{Get()}.{nameof(Scheme)}";
    }
}
