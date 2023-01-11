using System;
using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Extensions.Cache;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class CacheStoreValueTests
    {
        [Theory]
        [InlineData("cacheKey", "variableName")]
        public void CreatesCorrectPolicy(string key, string value)
        {
            const int duration = 5;
            var cachingType = CachingType.Internal;
            var basePolicy = new CacheStoreValue(key, value, TimeSpan.FromSeconds(5), cachingType);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(@$"<cache-store-value key=""{key}"" value=""{value}"" duration=""{duration}"" caching-type=""{cachingType.ToXmlString()}"" />");
        }
    }
}