using System.Net;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class MockResponseTests
    {
        [Theory]
        [InlineData(HttpStatusCode.Accepted, "application/json", "<mock-response status-code=\"202\" content-type=\"application/json\" />")]
        [InlineData(null, null, "<mock-response />")]
        public void CreatesCorrectPolicy(HttpStatusCode? statusCode, string contentType, string expected)
        {
            var basePolicy = new MockResponse(statusCode, contentType);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(expected);
        }
    }
}