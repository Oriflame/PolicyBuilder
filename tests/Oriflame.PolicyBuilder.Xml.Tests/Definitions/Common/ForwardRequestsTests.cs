using System;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class ForwardRequestsTests
    {
        [Theory]
        [InlineData(5)]
        public void CreatesCorrectPolicy(int timeoutSeconds)
        {
            var basePolicy = new ForwardRequest(TimeSpan.FromSeconds(timeoutSeconds));
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<forward-request timeout=\"{timeoutSeconds}\" />");
        }
        
        [Theory]
        [InlineData(5, true)]
        [InlineData(3, false)]
        public void CreatesCorrectBufferResponsePolicy(int timeoutSeconds, bool bufferResponse)
        {
            var basePolicy = new ForwardRequest(timeoutSeconds.ToString(), bufferResponse);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<forward-request timeout=\"{timeoutSeconds}\" buffer-response=\"{bufferResponse.ToString().ToLower()}\" />");
        }
    }
}