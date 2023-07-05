namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Request : ContextProperty
    {
        public Request(string parentPath) : base($"{parentPath}.{nameof(Request)}")
        {
            Body = new Body(_path.ToString());
            Certificate = new Certificate(_path);
            Headers = new Headers(_path);
            MatchedParameters = new MatchedParameters(_path);
            OriginalUrl = new Url(_path, nameof(OriginalUrl));
            Url = new Url(_path, nameof(Url));
        }

        /// <summary>
        /// Body of the request<br />
        /// </summary>
        public Body Body;

        /// <summary>
        /// Certificate of the request<br />
        /// </summary>
        public Certificate Certificate;

        /// <summary>
        /// Headers of the request<br />
        /// </summary>
        public Headers Headers;

        /// <summary>
        /// IpAddress of the request<br />
        /// </summary>
        public string IpAddress() => $"{this}.IpAddress";

        /// <summary>
        /// Matched route parameters of the request<br />
        /// </summary>
        public MatchedParameters MatchedParameters;

        /// <summary>
        /// Method of the request<br />
        /// </summary>
        public string Method() => $"{this}.Method";

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