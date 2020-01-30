using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class HeaderTests
    {
        [Theory]
        [InlineData("headerValue")]
        public void CreatesCorrectPolicy(string value)
        {
            var basePolicy = new Header(value);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<header>{value}</header>");
        }
    }
}
