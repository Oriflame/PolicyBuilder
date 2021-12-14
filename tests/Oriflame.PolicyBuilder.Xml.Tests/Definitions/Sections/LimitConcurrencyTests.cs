using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Sections
{
    public class LimitConcurrencyTests
    {
        [Theory]
        [InlineData("@(0 == 1)", 5)]
        public void CreatesCorrectSimplePolicy(string key, int maxCount)
        {
            var basePolicy = new LimitConcurrency(key, maxCount);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($@"<limit-concurrency key=""{key}"" max-count=""{maxCount}"" />");
        }
    }
}