using System;
using System.Collections.Generic;
using System.Text;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public enum Match
    {
        All,
        Any
    }

    public interface IRequiredClaimsSectionBuilder : IPolicySectionBuilder
    {
        IRequiredClaimsSectionBuilder SetClaimPolicy(string claimName, IEnumerable<string> claimValues, Match match, string separator);
    }
}
