using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Sections
{
    public class XmlOperationPolicyTests
    {
        [Fact]
        public void CreatesCorrectPolicy()
        {
            var basePolicy = new XmlOperationPolicy();
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                @"<policies>
  <inbound />
  <backend />
  <outbound />
  <on-error />
</policies>");
        }
    }
}