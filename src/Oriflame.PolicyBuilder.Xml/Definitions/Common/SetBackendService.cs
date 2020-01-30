namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class SetBackendService : PolicyXmlBase
    {
        public SetBackendService(string url) : base("set-backend-service")
        {
            Attributes.Add("base-url", url);
        }
    }
}