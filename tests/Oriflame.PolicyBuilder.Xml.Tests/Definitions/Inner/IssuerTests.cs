using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class IssuerTests
    {
        [Theory]
        [InlineData("https://customIssuer.com")]
        public void CreatesCorrectPolicy(string issuer)
        {
            var basePolicy = new Issuer(issuer);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<issuer>{issuer}</issuer>");
        }
    }
}