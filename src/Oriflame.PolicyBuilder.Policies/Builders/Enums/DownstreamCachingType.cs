namespace Oriflame.PolicyBuilder.Policies.Builders.Enums
{
    public enum DownstreamCachingType
    {
        /// <summary>
        /// Downstream caching is not allowed.
        /// </summary>
        None, 
        
        /// <summary>
        /// Downstream private caching is allowed.
        /// </summary>
        Private, 
        
        /// <summary>
        /// Private and shared downstream caching is allowed.
        /// </summary>
        Public
    }
}