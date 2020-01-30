using System.Net;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class SetStatusTests
    {
        [Theory]
        [InlineData(HttpStatusCode.BadGateway, "Bad Gateway")]
        public void CreatesCorrectPolicy(HttpStatusCode statusCode, string reason)
        {
            var code = ((int) statusCode).ToString();
            var basePolicy = new SetStatus(code, reason);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<set-status code=\"{code}\" reason=\"{reason}\" />");
        }
    }
}