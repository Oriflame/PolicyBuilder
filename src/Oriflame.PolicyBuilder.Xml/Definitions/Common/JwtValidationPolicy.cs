using System.Collections.Generic;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class JwtValidationPolicy : PolicyXmlBase
    {
        private readonly OpenIdConfig _openIdConfig;

        private readonly Issuers _issuers;

        private readonly SectionPolicy _requiredClaims;

        public JwtValidationPolicy(IDictionary<string, string> attributes, string openIdConfigUrl = null, IEnumerable<string> issuers = null, ISectionPolicy requiredClaims = null) : base("validate-jwt", attributes)
        {
            _openIdConfig = openIdConfigUrl != null ? new OpenIdConfig(openIdConfigUrl) : null;
            _issuers = issuers != null ? new Issuers(issuers) : null;
            _requiredClaims = requiredClaims as SectionPolicy;
        }

        public override XNode GetXml()
        {
            return CreateElement(_openIdConfig?.GetXml(), _issuers?.GetXml(), _requiredClaims?.GetXml());
        }
    }
}