namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class GraphQL : ContextProperty
    {
        public GraphQL(string parentPath) : base($"{parentPath}.{nameof(GraphQL)}")
        {
        }

        // TODO props
    }
}