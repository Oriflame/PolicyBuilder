using System;
using System.Collections.Generic;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class CacheStoreTests
    {
        [Theory]
        [InlineData(5)]
        public void CreatesCorrectPolicy(int seconds)
        {
            var basePolicy = new CacheStore(TimeSpan.FromSeconds(seconds));
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<cache-store duration=\"{seconds}\" />");
        }
        
        [Theory]
        [InlineData("5", true)]
        public void CreatesCorrectPolicy_OptionalCacheResponseAttributeIsGenerated(string seconds, bool cacheResponse)
        {
            var basePolicy = new CacheStore(seconds, new Dictionary<string, string>() { {"cache-response", cacheResponse.ToString().ToLower()}});
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<cache-store cache-response=\"true\" duration=\"{seconds}\" />");
        }
    }
}