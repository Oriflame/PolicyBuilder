namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Certificate : ContextProperty
    {

        public Certificate(string parentPath) : base($"{parentPath}.{nameof(Certificate)}")
        {
        }
        
        // TODO props
    }
}
