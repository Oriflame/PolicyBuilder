using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Url : ContextProperty, IUrl
    {
        public Url(string path) : base(path)
        {
            Query = new Query(GetPropertyPath(nameof(Query)));
        }

        public string Host => GetPropertyPath(nameof(Host));

        public string Path => GetPropertyPath(nameof(Path));

        public string Port => GetPropertyPath(nameof(Port));

        public IQuery Query { get; }

        public string QueryString => GetPropertyPath(nameof(QueryString));

        public string Scheme => GetPropertyPath(nameof(Scheme));
    }
}
