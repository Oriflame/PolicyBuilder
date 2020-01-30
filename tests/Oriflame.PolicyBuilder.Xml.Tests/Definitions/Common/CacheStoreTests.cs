using System;
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
    }
}