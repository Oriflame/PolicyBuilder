using System.Collections.Generic;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class JwtValidationPolicyTests
    {
        [Theory]
        [InlineData(null, null)]
        public void CreatesCorrectPolicy(string openIdConfigUrl, string[] issuers)
        {
            var basePolicy = new JwtValidationPolicy(new Dictionary<string, string>(), openIdConfigUrl, issuers);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be("<validate-jwt />");
        }

        [Theory]
        [InlineData("https://openIdConfigUrl.com", new[] { "https://issuer1.com", "https://issuer2.com" })]
        public void CreatesCorrectComplexPolicy(string openIdConfigUrl, string[] issuers)
        {
            var basePolicy = new JwtValidationPolicy(new Dictionary<string, string>(), openIdConfigUrl, issuers);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
$@"<validate-jwt>
  <openid-config url=""https://openIdConfigUrl.com"" />
  <issuers>
    <issuer>https://issuer1.com</issuer>
    <issuer>https://issuer2.com</issuer>
  </issuers>
</validate-jwt>");
        }
    }
}