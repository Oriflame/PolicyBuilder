namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IContext : IContextProperty
    {
        IApi Api { get; }
        IDeployment Deployment { get; }
        string Elapsed { get; }
        IGraphQL GraphQL { get; }
        ILastError LastError { get; }
        IOperation Operation { get; }
        IRequest Request { get; }
        string RequestId { get; }
        IResponse Response { get; }
        ISubscription Subscription { get; }
        string Timestamp { get; }
        string Tracing { get; }
        IUser User { get; }
        IVariables Variables { get; }

        string Trace(string message);
    }
}