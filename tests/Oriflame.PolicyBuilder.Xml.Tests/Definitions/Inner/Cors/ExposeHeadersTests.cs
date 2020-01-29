using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner.Cors;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner.Cors
{
    public class ExposeHeadersTests
    {
        [Theory]
        [InlineData("x-test-header1", "x-test-header2")]
        public void CreatesCorrectPolicy(string header1, string header2)
        {
            var basePolicy = new ExposeHeaders(new []{ header1, header2 });
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                @$"<expose-headers>
  <header>{header1}</header>
  <header>{header2}</header>
</expose-headers>");
        }
    }
}