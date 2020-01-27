using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class SetBodyLiquidTests
    {
        [Theory]
        [InlineData("{ id: 22 }")]
        public void CreatesCorrectPolicy(string content)
        {
            var basePolicy = new SetBodyLiquid(new LiquidTemplate(content));
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<set-body template=\"liquid\">{content}</set-body>");
        }
    }
}