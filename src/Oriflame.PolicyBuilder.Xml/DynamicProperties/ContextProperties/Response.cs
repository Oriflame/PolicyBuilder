using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Response : ContextProperty, IResponse
    {
        public Response(string path) : base(path)
        {
            Body = new Body($"{Get()}.{nameof(Body)}");
            Headers = new Headers($"{Get()}.{nameof(Headers)}");
        }

        /// <summary>
        /// Body of the response<br />
        /// </summary>
        public IBody Body { get; }

        /// <summary>
        /// Headers of the response<br />
        /// </summary>
        public IHeaders Headers { get; }

        public string StatusCode => $"{Get()}.{StatusCode}";

        public string StatusReason => $"{Get()}.{StatusReason}";
    }
}
