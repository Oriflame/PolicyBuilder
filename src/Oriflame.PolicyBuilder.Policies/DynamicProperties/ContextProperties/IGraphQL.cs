namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IGraphQL : IContextProperty
    {
        IGraphQLDataObject GraphQLArguments { get; }
        IGraphQLDataObject Parent { get; }
    }
}