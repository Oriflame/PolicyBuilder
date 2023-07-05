namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class SubscriptionKeyParameterNames : ContextProperty
    {
        public SubscriptionKeyParameterNames(string path) : base(path)
        {
        }

        public string Header => $"{Get()}.{nameof(Header)}";

        public string Query => $"{Get()}.{nameof(Query)}";
    }
}
