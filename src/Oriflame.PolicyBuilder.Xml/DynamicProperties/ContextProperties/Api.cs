namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Api : ContextProperty
    {
        public Api(string parentPath) : base($"{parentPath}.{nameof(Api)}")
        {
        }

        // TODO props
    }
}