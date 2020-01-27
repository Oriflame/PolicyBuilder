using System.Collections.Generic;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class JwtValidationPolicyTests
    {
        [Theory]
        //[InlineData("https://openIdConfigUrl.com", new[] { "https://issuer1.com", "https://issuer2.com" })]
        [InlineData(null, null, "<validate-jwt />")]
        public void CreatesCorrectPolicy(string openIdConfigUrl, string[] issuers, string expected)
        {
            var basePolicy = new JwtValidationPolicy(new Dictionary<string, string>(), openIdConfigUrl, issuers);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(expected);
        }
    }
}