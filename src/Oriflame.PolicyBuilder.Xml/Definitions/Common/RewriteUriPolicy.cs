namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class RewriteUriPolicy : PolicyXmlBase
    {
        public RewriteUriPolicy(string uriTemplate) : base("rewrite-uri")
        {
            Attributes.Add("template", uriTemplate);
        }
    }
}