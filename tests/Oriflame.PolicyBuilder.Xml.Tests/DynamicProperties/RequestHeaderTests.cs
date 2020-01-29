using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.DynamicProperties
{
    public class RequestHeaderTests
    {
        [Theory]
        [InlineData("testingVariable", "default", false, "@(context.Request.Headers.GetValueOrDefault(\"testingVariable\", \"default\"))")]
        [InlineData("testingVariable", "default", true, "context.Request.Headers.GetValueOrDefault(\"testingVariable\", \"default\")")]
        [InlineData("testingVariable", null, true, "context.Request.Headers.GetValueOrDefault(\"testingVariable\")")]
        public void RequestHeaderGeneratesCorrectPolicy(string variableName, string defaultValue, bool inline,  string expected)
        {
            var policy = RequestHeader.Get(variableName, defaultValue, inline);
            policy.Should().Be(expected);
        }
    }
}
