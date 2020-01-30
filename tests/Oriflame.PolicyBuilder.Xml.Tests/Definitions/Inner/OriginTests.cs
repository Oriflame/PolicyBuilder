using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class OriginTests
    {
        [Theory]
        [InlineData("https://corsUrl.com")]
        public void CreatesCorrectPolicy(string url)
        {
            var basePolicy = new Origin(url);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<origin>{url}</origin>");
        }
    }
}