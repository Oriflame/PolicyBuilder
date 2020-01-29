using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.DynamicProperties
{
    public class NamedValueTests
    {
        [Theory]
        [InlineData("testingVariable", "{{testingVariable}}")]
        public void GetGeneratesCorrectPolicy(string variableName, string expected)
        {
            var policy = NamedValue.Get(variableName);
            policy.Should().Be(expected);
        }
    }
}
