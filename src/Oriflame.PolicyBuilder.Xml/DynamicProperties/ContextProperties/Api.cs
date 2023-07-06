using System.Collections;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Api : ContextProperty, IApi
    {
        public Api(string path) : base(path)
        {
            SubscriptionKeyParameterNames = new SubscriptionKeyParameterNames($"{Get()}.{nameof(SubscriptionKeyParameterNames)}");
        }

        public string Id => $"{Get()}.{nameof(Id)}";

        public string Name => $"{Get()}.{nameof(Name)}";

        public string Path => $"{Get()}.{nameof(Path)}";

        /// <summary>
        /// Type: <see cref="IEnumerable{string}"/>
        /// </summary>
        public string Protocols => $"{Get()}.{nameof(Protocols)}";

        public IUrl ServiceUrl => new Url($"{Get()}.{nameof(ServiceUrl)}");

        public ISubscriptionKeyParameterNames SubscriptionKeyParameterNames { get; }
    }
}