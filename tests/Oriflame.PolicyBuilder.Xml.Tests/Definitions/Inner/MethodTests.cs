using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class MethodTests
    {
        [Theory]
        [InlineData("POST")]
        [InlineData("*")]
        public void CreatesCorrectPolicy(string httpMethod)
        {
            var basePolicy = new Method(httpMethod);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<method>{httpMethod}</method>");
        }
    }
}