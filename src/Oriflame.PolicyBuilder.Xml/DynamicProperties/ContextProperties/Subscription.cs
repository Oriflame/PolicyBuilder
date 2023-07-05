namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Subscription : ContextProperty
    {
        public Subscription(string parentPath) : base($"{parentPath}.{nameof(Subscription)}")
        {
        }
    }
}