using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class RequiredClaimsSectionBuilder : SectionBuilderBase<IRequiredClaimsSectionBuilder>, IRequiredClaimsSectionBuilder
    {
        public RequiredClaimsSectionBuilder() : base(new SectionPolicy("required-claims"))
        {
        }

        public IRequiredClaimsSectionBuilder SetClaimPolicy(string claimName, IEnumerable<string> claimValues, RequiredClaimsMatch match, string separator = "")
        {
            return AddPolicyDefinition(new Claim(claimName, claimValues, match, separator));
        }
    }
}
