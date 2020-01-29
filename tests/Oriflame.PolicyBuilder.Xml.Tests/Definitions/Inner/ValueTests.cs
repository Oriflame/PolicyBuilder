using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class ValueTests
    {
        [Theory]
        [InlineData("testValue")]
        public void CreatesCorrectPolicy(string value)
        {
            var basePolicy = new Value(value);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<value>{value}</value>");
        }
    }
}