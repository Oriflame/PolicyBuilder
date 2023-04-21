using System;

namespace Oriflame.PolicyBuilder.Policies.Builders.Enums
{
    public enum ExistsAction
    {
        Override,
        Skip,
        Append,
        [Obsolete("Please use 'Delete' action")]
        Delete
    }
}