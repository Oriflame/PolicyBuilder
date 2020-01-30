using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Policies.Definitions
{
    public abstract class PolicyBase : IPolicy
    {
        protected readonly IDictionary<string, string> Attributes;

        protected PolicyBase(IDictionary<string, string> attributes)
        {
            Attributes = attributes ?? new Dictionary<string, string>();
        }
    }
}