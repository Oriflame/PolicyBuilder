using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public IInboundSectionPolicyBuilder ValidateJwt(Func<IJwtValidationAttributesBuilder, IDictionary<string, string>> jwtAttributesBuilder, string openIdConfigUrl = null,
            IEnumerable<string> issuers = null, Func<IRequiredClaimsSectionBuilder, ISectionPolicy> requiredClaimsAction = null)
        {
            var attributesBuilder = new JwtAttributesBuilder();
            var attributes = jwtAttributesBuilder.Invoke(attributesBuilder);
            var requiredClaimsSectionBuilder = new RequiredClaimsSectionBuilder();
            var requiredClaims = requiredClaimsAction?.Invoke(requiredClaimsSectionBuilder);
            var policy = new JwtValidationPolicy(attributes, openIdConfigUrl, issuers, requiredClaims);
            return AddPolicyDefinition(policy);
        }
    }
}
