using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class ConditionTests
    {
        [Theory]
        [InlineData("@(0 == 1)")]
        public void CreatesCorrectPolicy(string condition)
        {
            var basePolicy = new When(condition);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<when condition=\"{condition}\" />");
        }
    }
}