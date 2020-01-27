using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class SetBodyTests
    {
        [Theory]
        [InlineData("{ id: 22 }")]
        public void CreatesCorrectPolicy(string content)
        {
            var basePolicy = new SetBody(content);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<set-body>{content}</set-body>");
        }
    }
}