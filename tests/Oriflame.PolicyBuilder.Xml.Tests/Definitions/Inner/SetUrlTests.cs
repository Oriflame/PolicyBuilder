using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class SetUrlTests
    {
        [Theory]
        [InlineData("https://customUrl.com")]
        public void CreatesCorrectPolicy(string url)
        {
            var basePolicy = new SetUrl(url);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<set-url>{url}</set-url>");
        }
    }
}