using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions
{
    public interface ICacheValue<out TSection> : ISetVariable<TSection> where TSection : IPolicySectionBuilder
    {
        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies#GetFromCacheByKey"/>
        TSection CacheLookupValue(string key, string variable);

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies#StoreToCacheByKey"/>
        TSection CacheStoreValue(string key, string value, TimeSpan duration);
    }
}