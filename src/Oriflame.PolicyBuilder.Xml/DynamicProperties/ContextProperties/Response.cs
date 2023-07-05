namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Response : ContextProperty
    {
        public Response(string path) : base(path)
        {
            Body = new Body($"{Get()}.{nameof(Body)}");
            Headers = new Headers($"{Get()}.{nameof(Headers)}");
        }

        /// <summary>
        /// Body of the response<br />
        /// </summary>
        public Body Body;

        /// <summary>
        /// Headers of the response<br />
        /// </summary>
        public Headers Headers;

        public string StatusCode => $"{Get()}.{StatusCode}";

        public string StatusReason => $"{Get()}.{StatusReason}";
    }
}