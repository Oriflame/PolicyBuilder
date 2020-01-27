using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class TraceTests
    {
        [Theory]
        [InlineData("traceSource", "traceContent")]
        public void CreatesCorrectPolicy(string source, string content)
        {
            var basePolicy = new Trace(source, content);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<trace source=\"{source}\">{content}</trace>");
        }
    }
}