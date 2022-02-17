using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class RewriteUriPolicy : PolicyXmlBase
    {
        public RewriteUriPolicy(string uriTemplate) : base("rewrite-uri")
        {
            Attributes.Add("template", uriTemplate);
        }
        
        public RewriteUriPolicy(string uriTemplate, bool copyUnmatchedParams) : base("rewrite-uri")
        {
            Attributes.Add("template", uriTemplate);
            Attributes.Add("copy-unmatched-params", BoolMapper.Map(copyUnmatchedParams));
        }
    }
}