namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Request : ContextProperty
    {
        public Request(string path) : base(path)
        {
            Body = new Body($"{Get()}.{nameof(Body)}");
            Headers = new Headers($"{Get()}.{nameof(Headers)}");
            MatchedParameters = new MatchedParameters($"{Get()}.{nameof(MatchedParameters)}");
            OriginalUrl = new Url($"{Get()}.{nameof(OriginalUrl)}");
            Url = new Url($"{Get()}.{nameof(Url)}");
        }

        /// <summary>
        /// Body of the request<br />
        /// </summary>
        public Body Body;

        /// <summary>
        /// Certificate of the request<br />
        /// </summary>
        public string Certificate => $"{Get()}.{nameof(Certificate)}";

        /// <summary>
        /// Headers of the request<br />
        /// </summary>
        public Headers Headers;

        /// <summary>
        /// IpAddress of the request<br />
        /// </summary>
        public string IpAddress => $"{Get()}.{nameof(IpAddress)}";

        /// <summary>
        /// Matched route parameters of the request<br />
        /// </summary>
        public MatchedParameters MatchedParameters;

        /// <summary>
        /// Method of the request<br />
        /// </summary>
        public string Method => $"{this}.{Method}";

        /// <summary>
        /// Original Url of the request<br />
        /// </summary>
        public Url OriginalUrl;

        /// <summary>
        /// URL of the backend<br />
        /// </summary>
        public Url Url;
    }
}