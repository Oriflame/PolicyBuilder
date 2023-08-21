namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IOperation : IContextProperty
    {
        string Id { get; }
        string Method { get; }
        string Name { get; }
        string UrlTemplate { get; }
    }
}