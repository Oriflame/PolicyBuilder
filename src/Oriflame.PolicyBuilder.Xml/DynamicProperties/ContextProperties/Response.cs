namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Response : ContextProperty
    {
        public Response(string parentPath) : base($"{parentPath}.{nameof(Response)}")
        {
            Body = new Body(_path.ToString());
            Headers = new Headers(_path);
        }

        /// <summary>
        /// Body of the response<br />
        /// </summary>
        public Body Body;

        /// <summary>
        /// Headers of the response<br />
        /// </summary>
        public Headers Headers;

        public string StatusCode => $"{this}.StatusCode";

        public string StatusReason => $"{this}.StatusReason";
    }
}