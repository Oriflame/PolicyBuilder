using System;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class ForwardRequestsTests
    {
        [Theory]
        [InlineData("5")]
        public void CreatesCorrectPolicy(string timeoutSeconds)
        {
            var basePolicy = new ForwardRequest(timeoutSeconds);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<forward-request timeout=\"{timeoutSeconds}\" />");
        }
    }
}