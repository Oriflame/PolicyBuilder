using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Request : ContextProperty, IRequest
    {
        public Request(string path) : base(path)
        {
            Body = new Body($"{GetPropertyPath()}.{nameof(Body)}");
            Headers = new Headers($"{GetPropertyPath()}.{nameof(Headers)}");
            MatchedParameters = new MatchedParameters($"{GetPropertyPath()}.{nameof(MatchedParameters)}");
            OriginalUrl = new Url($"{GetPropertyPath()}.{nameof(OriginalUrl)}");
            Url = new Url($"{GetPropertyPath()}.{nameof(Url)}");
        }

        /// <summary>
        /// Body of the request<br />
        /// </summary>
        public IBody Body { get; }

        /// <summary>
        /// Certificate of the request<br />
        /// </summary>
        public string Certificate => $"{GetPropertyPath()}.{nameof(Certificate)}";

        /// <summary>
        /// Headers of the request<br />
        /// </summary>
        public IHeaders Headers { get; }

        /// <summary>
        /// IpAddress of the request<br />
        /// </summary>
        public string IpAddress => $"{GetPropertyPath()}.{nameof(IpAddress)}";

        /// <summary>
        /// Matched route parameters of the request<br />
        /// </summary>
        public IMatchedParameters MatchedParameters { get; }

        /// <summary>
        /// Method of the request<br />
        /// </summary>
        public string Method => $"{GetPropertyPath()}.{Method}";

        /// <summary>
        /// Original Url of the request<br />
        /// </summary>
        public IUrl OriginalUrl { get; }

        /// <summary>
        /// URL of the backend<br />
        /// </summary>
        public IUrl Url { get; }
    }
}