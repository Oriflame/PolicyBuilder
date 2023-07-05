using Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    public class Context : ContextProperty
    {
        public Api Api;

        public Deployment Deployment;

        /// <summary>
        /// Elapsed: TimeSpan - time interval between the value of Timestamp and current time
        /// </summary>
        public string Elapsed => $"{_path}.{nameof(Elapsed)}";

        public GraphQL GraphQL;

        public LastError LastError;

        public Operation Operation;

        public Request Request;

        /// <summary>
        /// RequestId: Guid - unique request identifier
        /// </summary>
        public string RequestId => $"{_path}.{nameof(RequestId)}";

        public Response Response;

        public Subscription Subscription;

        /// <summary>
        /// Timestamp: DateTime - point in time when request was received
        /// </summary>
        public string Timestamp => $"{_path}.{nameof(Timestamp)}";

        /// <summary>
        /// Tracing: bool - indicates if tracing is on or off
        /// </summary>
        public string Tracing => $"{_path}.{nameof(Tracing)}";

        public User User;

        public Variables Variables;

        string Trace(string message) => @$"{_path}.{nameof(Trace)}(""{message}"")";

        public Context() : base("context")
        {
            Api = new Api(_path);
            Deployment = new Deployment(_path);
            GraphQL = new GraphQL(_path);
            LastError = new LastError(_path);
            Operation = new Operation(_path);
            Request = new Request(_path);
            Response = new Response(_path);
            Subscription = new Subscription(_path);
            User = new User(_path);
            Variables = new Variables(_path);
        }
    }
}
