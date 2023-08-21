namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IResponse : IContextProperty
    {
        IBody Body { get; }
        IHeaders Headers { get; }
        string StatusCode { get; }
        string StatusReason { get; }
    }
}