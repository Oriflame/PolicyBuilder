using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class RequiredClaimsSectionBuilderTests
    {
        [Fact]
        public void CreatesCorrectPolicyWithTwoClaimPolicies()
        {
            var claim1 = "claim1";
            var claim1Value1 = "value11";
            var claim1Value2 = "value12";
            var claim1Match = Match.All;
            var claim1Separator = ";";

            var claim2 = "claim2";
            var claim2Value1 = "value21";
            var claim2Value2 = "value22";
            var claim2Match = Match.Any;
            var claim2Separator = ",";

            var sectionPolicy =
                new RequiredClaimsSectionBuilder()
                    .SetClaimPolicy(claim1, new[] { claim1Value1, claim1Value2 }, claim1Match, claim1Separator)
                    .SetClaimPolicy(claim2, new[] { claim2Value1, claim2Value2 }, claim2Match, claim2Separator)
                    .Create();

            var xml = ((SectionPolicy)sectionPolicy).GetXml().ToString();
            xml.Should().Be(
$@"<required-claims>
  <claim name=""{claim1}"" match=""{claim1Match}"" separator=""{claim1Separator}"">
    <value>{claim1Value1}</value>
    <value>{claim1Value2}</value>
  </claim>
  <claim name=""{claim2}"" match=""{claim2Match}"" separator=""{claim2Separator}"">
    <value>{claim2Value1}</value>
    <value>{claim2Value2}</value>
  </claim>
</required-claims>");
        }
    }
}
