using Oriflame.PolicyBuilder.Policies.Builders.Enums;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes
{
    public interface ICacheLookupAttributesBuilder : IAttributesBuilder
    {
        /// <summary>
        /// Set to true to cache responses per subscription key. Required.
        /// </summary>
        ICacheLookupAttributesBuilder VaryByDeveloper(bool value);

        /// <summary>
        /// Set to true to cache responses per user group. Required.
        /// </summary>
        ICacheLookupAttributesBuilder VaryByDeveloperGroups(bool value);

        /// <summary>
        /// When set to true, allows caching of requests that contain an Authorization header.
        /// </summary>
        ICacheLookupAttributesBuilder AllowPrivateResponseCaching(bool value);
        
        /// <summary>
        /// Sets caching to public, private or no-cache.
        /// </summary>
        ICacheLookupAttributesBuilder DownstreamCachingType(DownstreamCachingType downstreamCachingType);
        
        /// <summary>
        /// When downstream caching is enabled this attribute turns on or off the must-revalidate cache control directive in gateway responses. Default true.
        /// </summary>
        ICacheLookupAttributesBuilder MustRevalidate(bool value);
    }
}