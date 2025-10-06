namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IApi : IContextProperty
    {
        string Id { get; }
        string Name { get; }
        string Path { get; }
        string Protocols { get; }
        IUrl ServiceUrl { get; }
    }
}