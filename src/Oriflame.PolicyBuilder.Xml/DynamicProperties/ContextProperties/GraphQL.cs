namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class GraphQL : ContextProperty
    {
        public GraphQL(string path) : base(path)
        {
            GraphQLArguments = new GraphQLDataObject($"{path}.{nameof(GraphQLArguments)}");
            Parent = new GraphQLDataObject($"{path}.{nameof(Parent)}");
        }

        public GraphQLDataObject GraphQLArguments;

        public GraphQLDataObject Parent;
    }
}