using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Sections
{
    public class SectionPolicyTests
    {
        [Theory]
        [InlineData("test")]
        public void CreatesCorrectPolicy(string sectionName)
        {
            var basePolicy = new SectionPolicy(sectionName);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($@"<{sectionName} />");
        }
    }
}