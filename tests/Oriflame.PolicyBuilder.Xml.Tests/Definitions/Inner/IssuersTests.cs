using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class IssuersTests
    {
        [Theory]
        [InlineData( "https://customIssuer1.com","https://customIssuer2.com")]
        public void CreatesCorrectPolicy(string issuer1, string issuer2)
        {
            var basePolicy = new Issuers(new [] {issuer1, issuer2});
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                @$"<issuers>
  <issuer>{issuer1}</issuer>
  <issuer>{issuer2}</issuer>
</issuers>");
        }
    }
}