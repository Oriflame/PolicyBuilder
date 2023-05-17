using System;

namespace Oriflame.PolicyBuilder.Policies.Builders.Enums
{
    /// <summary>
    /// Type of cache to use.
    /// </summary>
    public enum CachingType
    {
        /// <summary>
        /// The built-in API Management cache
        /// </summary>
        Internal,

        /// <summary>
        /// The external cache as described in Use an external Azure Cache for Redis in Azure API Management
        /// </summary>
        External,

        /// <summary>
        /// External cache if configured or internal cache otherwise
        /// </summary>
        PreferExternal
    }
}
