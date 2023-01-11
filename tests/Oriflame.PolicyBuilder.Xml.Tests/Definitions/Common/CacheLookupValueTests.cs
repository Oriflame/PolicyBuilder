using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Extensions.Cache;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class CacheLookupValueTests
    {
        [Theory]
        [InlineData("cacheKey", "variableName")]
        public void CreatesCorrectPolicy(string key, string variableName)
        {
            var cachingType = CachingType.PreferExternal;
            var basePolicy = new CacheLookupValuePolicy(key, variableName, cachingType);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(@$"<cache-lookup-value key=""{key}"" variable-name=""{variableName}"" caching-type=""{cachingType.ToXmlString()}"" />");
        }
    }
}