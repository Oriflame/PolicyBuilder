using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;

namespace Oriflame.PolicyBuilder.Xml.Extensions.Cache
{
    /// <summary>
    /// Caching type extensions.
    /// </summary>
    public static class CachingTypeExtensions
    {
        /// <summary>
        /// Converts <see cref="CachingType"/> to XML string.
        /// </summary>
        /// <param name="cachingType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ToXmlString(this CachingType cachingType)
        {
            return cachingType switch
            {
                CachingType.Internal => "internal",
                CachingType.External => "external",
                CachingType.PreferExternal => "prefer-external",
                _ => throw new ArgumentOutOfRangeException(nameof(cachingType), cachingType, "Value doesn't exist in the enum"),
            };
        }
    }
}
