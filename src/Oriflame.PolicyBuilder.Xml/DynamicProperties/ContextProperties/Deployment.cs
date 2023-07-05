namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Deployment : ContextProperty
    {
        public Deployment(string parentPath) : base($"{parentPath}.{nameof(Deployment)}")
        {
        }

        // TODO props
    }
}