namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Url : ContextProperty
    {
        public Url(string parentPath, string propertyName) : base($"{parentPath}.{propertyName}")
        {
        }

        public string Host => $"{this}.{nameof(Host)}";

        public string Path => $"{this}.{nameof(Path)}";

        public string Port => $"{this}.{nameof(Port)}";

        public Query Query => new Query(ToString());

        public string QueryString => $"{this}.{nameof(QueryString)}";

        public string Scheme => $"{this}.{nameof(Scheme)}";
    }
}
