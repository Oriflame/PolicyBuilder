using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class GraphQL : ContextProperty, IGraphQL
    {
        public GraphQL(string path) : base(path)
        {
            GraphQLArguments = new GraphQLDataObject($"{path}.{nameof(GraphQLArguments)}");
            Parent = new GraphQLDataObject($"{path}.{nameof(Parent)}");
        }

        public IGraphQLDataObject GraphQLArguments { get; }

        public IGraphQLDataObject Parent { get; }
    }
}