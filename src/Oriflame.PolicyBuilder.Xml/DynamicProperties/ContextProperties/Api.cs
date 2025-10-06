using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Api : ContextProperty, IApi
    {
        public Api(string path) : base(path)
        {
            SubscriptionKeyParameterNames = new SubscriptionKeyParameterNames(GetPropertyPath(nameof(SubscriptionKeyParameterNames)));
        }

        public string Id => GetPropertyPath(nameof(Id));

        public string Name => GetPropertyPath(nameof(Name));

        public string Path => GetPropertyPath(nameof(Path));

        /// <summary>
        /// Type: <see cref="IEnumerable{string}"/>
        /// </summary>
        public string Protocols => nameof(Protocols);

        public IUrl ServiceUrl => new Url(GetPropertyPath(nameof(ServiceUrl)));

        public ISubscriptionKeyParameterNames SubscriptionKeyParameterNames { get; }
    }
}