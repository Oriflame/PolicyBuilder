using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class SubscriptionKeyParameterNames : ContextProperty, ISubscriptionKeyParameterNames
    {
        public SubscriptionKeyParameterNames(string path) : base(path)
        {
        }

        public string Header => $"{Get()}.{nameof(Header)}";

        public string Query => $"{Get()}.{nameof(Query)}";
    }
}
