using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class CacheLookupValueTests
    {
        [Theory]
        [InlineData("cacheKey", "variableName")]
        public void CreatesCorrectPolicy(string key, string variableName)
        {
            var basePolicy = new CacheLookupValuePolicy(key, variableName);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<cache-lookup-value key=\"{key}\" variable-name=\"{variableName}\" />");
        }
    }
}