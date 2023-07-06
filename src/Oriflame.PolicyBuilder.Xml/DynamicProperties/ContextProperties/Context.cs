using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Context : ContextProperty, IContext
    {
        public IApi Api { get; }

        public IDeployment Deployment { get; }

        /// <summary>
        /// Elapsed: TimeSpan - time interval between the value of Timestamp and current time
        /// </summary>
        public string Elapsed => $"{Get()}.{nameof(Elapsed)}";

        public IGraphQL GraphQL { get; }

        public ILastError LastError { get; }

        public IOperation Operation { get; }

        public IRequest Request { get; }

        /// <summary>
        /// RequestId: Guid - unique request identifier
        /// </summary>
        public string RequestId => $"{Get()}.{nameof(RequestId)}";

        public IResponse Response { get; }

        public ISubscription Subscription { get; }

        /// <summary>
        /// Timestamp: DateTime - point in time when request was received
        /// </summary>
        public string Timestamp => $"{Get()}.{nameof(Timestamp)}";

        /// <summary>
        /// Tracing: bool - indicates if tracing is on or off
        /// </summary>
        public string Tracing => $"{Get()}.{nameof(Tracing)}";

        public IUser User { get; }

        public IVariables Variables { get; }

        public string Trace(string message) => @$"{Get()}.{nameof(Trace)}(""{message}"")";

        public Context() : base("context")
        {
            Api = new Api($"{Get()}.{nameof(Api)}");
            Deployment = new Deployment($"{Get()}.{nameof(Deployment)}");
            GraphQL = new GraphQL($"{Get()}.{nameof(GraphQL)}");
            LastError = new LastError($"{Get()}.{nameof(LastError)}");
            Operation = new Operation($"{Get()}.{nameof(Operation)}");
            Request = new Request($"{Get()}.{nameof(Request)}");
            Response = new Response($"{Get()}.{nameof(Response)}");
            Subscription = new Subscription($"{Get()}.{nameof(Subscription)}");
            User = new User($"{Get()}.{nameof(User)}");
            Variables = new Variables($"{Get()}.{nameof(Variables)}");
        }
    }
}
