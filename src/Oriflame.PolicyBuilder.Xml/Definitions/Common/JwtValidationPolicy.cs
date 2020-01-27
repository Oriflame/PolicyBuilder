using System.Collections.Generic;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class JwtValidationPolicy : PolicyXmlBase
    {
        private readonly OpenIdConfig _openIdConfig;

        private readonly Issuers _issuers;

        public JwtValidationPolicy(IDictionary<string, string> attributes, string openIdConfigUrl = null, IEnumerable<string> issuers = null) : base("validate-jwt", attributes)
        {
            _openIdConfig = openIdConfigUrl != null ? new OpenIdConfig(openIdConfigUrl) : null;
            _issuers = issuers != null ? new Issuers(issuers) : null;
        }

        public override XNode GetXml()
        {
            return CreateElement(_openIdConfig?.GetXml(), _issuers?.GetXml());
        }
    }
}