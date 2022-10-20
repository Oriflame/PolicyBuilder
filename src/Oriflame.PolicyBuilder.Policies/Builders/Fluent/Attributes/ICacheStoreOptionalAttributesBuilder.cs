namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes
{
    public interface ICacheStoreOptionalAttributesBuilder : IAttributesBuilder
    {
        /// <summary>
        /// Set to true to cache the current HTTP response. If the attribute is omitted or set to false, only HTTP responses with the status code '200 OK' are cached.
        /// </summary>
        ICacheStoreOptionalAttributesBuilder CacheResponse(bool value);
    }
}
