using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Response : ContextProperty, IResponse
    {
        public Response(string path) : base(path)
        {
            Body = new Body($"{GetPropertyPath()}.{nameof(Body)}");
            Headers = new Headers($"{GetPropertyPath()}.{nameof(Headers)}");
        }

        /// <summary>
        /// Body of the response<br />
        /// </summary>
        public IBody Body { get; }

        /// <summary>
        /// Headers of the response<br />
        /// </summary>
        public IHeaders Headers { get; }

        public string StatusCode => $"{GetPropertyPath()}.{nameof(StatusCode)}";

        public string StatusReason => $"{GetPropertyPath()}.{nameof(StatusReason)}";
    }
}
