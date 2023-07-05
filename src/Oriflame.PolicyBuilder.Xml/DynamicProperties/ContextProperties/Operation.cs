namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Operation : ContextProperty
    {
        public Operation(string parentPath) : base($"{parentPath}.{nameof(Operation)}")
        {
        }

        // TODO props
    }
}