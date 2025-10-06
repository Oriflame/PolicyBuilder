using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class GraphQLDataObject : ContextProperty, IGraphQLDataObject
    {
        public GraphQLDataObject(string path) : base(path)
        {
        }

        // TODO props
    }
}