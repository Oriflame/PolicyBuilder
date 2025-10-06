namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IUrl : IContextProperty
    {
        string Host { get; }
        string Path { get; }
        string Port { get; }
        IQuery Query { get; }
        string QueryString { get; }
        string Scheme { get; }
    }
}