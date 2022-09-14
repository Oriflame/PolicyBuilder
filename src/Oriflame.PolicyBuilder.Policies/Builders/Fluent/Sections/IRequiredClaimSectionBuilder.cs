using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{

    public interface IRequiredClaimsSectionBuilder : IPolicySectionBuilder
    {
        IRequiredClaimsSectionBuilder SetClaimPolicy(string claimName, IEnumerable<string> claimValues, RequiredClaimsMatch match, string separator = "");
    }
}
