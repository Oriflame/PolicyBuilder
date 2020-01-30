namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class OpenIdConfig : PolicyXmlBase
    {
        public OpenIdConfig(string url) : base("openid-config")
        {
            Attributes.Add("url", url);
        }
    }
}