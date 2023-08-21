namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface ILastError : IContextProperty
    {
        string Message { get; }
        string Path { get; }
        string PolicyId { get; }
        string Reason { get; }
        string Scope { get; }
        string Section { get; }
        string Source { get; }
    }
}