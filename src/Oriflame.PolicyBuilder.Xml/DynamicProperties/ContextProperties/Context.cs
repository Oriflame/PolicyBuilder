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
        public string Elapsed => GetPropertyPath(nameof(Elapsed));

        public IGraphQL GraphQL { get; }

        public ILastError LastError { get; }

        public IOperation Operation { get; }

        public IRequest Request { get; }

        /// <summary>
        /// RequestId: Guid - unique request identifier
        /// </summary>
        public string RequestId => GetPropertyPath(RequestId);

        public IResponse Response { get; }

        public ISubscription Subscription { get; }

        /// <summary>
        /// Timestamp: DateTime - point in time when request was received
        /// </summary>
        public string Timestamp => GetPropertyPath(nameof(Timestamp));

        /// <summary>
        /// Tracing: bool - indicates if tracing is on or off
        /// </summary>
        public string Tracing => GetPropertyPath(nameof(Tracing));

        public IUser User { get; }

        public IVariables Variables { get; }

        public string Trace(string message) => GetPropertyPath(@$"{nameof(Trace)}(""{message}"")");

        public Context() : base("context")
        {
            Api = new Api(GetPropertyPath(nameof(Api)));
            Deployment = new Deployment(GetPropertyPath(nameof(Deployment)));
            GraphQL = new GraphQL(GetPropertyPath(nameof(GraphQL)));
            LastError = new LastError(GetPropertyPath(nameof(LastError)));
            Operation = new Operation(GetPropertyPath(nameof(Operation)));
            Request = new Request(GetPropertyPath(nameof(Request)));
            Response = new Response(GetPropertyPath(nameof(Response)));
            Subscription = new Subscription(GetPropertyPath(nameof(Subscription)));
            User = new User(GetPropertyPath(nameof(User)));
            Variables = new Variables(GetPropertyPath(nameof(Variables)));
        }
    }
}
