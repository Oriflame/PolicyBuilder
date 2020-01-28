using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner.Cors;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner.Cors
{
    public class AllowedOriginsTests
    {
        [Theory]
        [InlineData("http://origin1.com", "http://origin2.com")]
        public void CreatesCorrectPolicy(string origin1, string origin2)
        {
            var basePolicy = new AllowedOrigins(new []{ origin1, origin2 });
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                @$"<allowed-origins>
  <origin>{origin1}</origin>
  <origin>{origin2}</origin>
</allowed-origins>");
        }
    }
}