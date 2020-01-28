using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class OpenIdConfigTests
    {
        [Theory]
        [InlineData("https://wellKnownUrl.com")]
        public void CreatesCorrectPolicy(string url)
        {
            var basePolicy = new OpenIdConfig(url);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<openid-config url=\"{ url }\" />");
        }
    }
}