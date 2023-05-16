using System.Collections.Generic;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class ForwardRequestsTests
    {
        [Fact]
        public void CreatesCorrectPolicy()
        {
            var basePolicy = new ForwardRequest(new Dictionary<string, string>());
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<forward-request />");
        }
    }
}