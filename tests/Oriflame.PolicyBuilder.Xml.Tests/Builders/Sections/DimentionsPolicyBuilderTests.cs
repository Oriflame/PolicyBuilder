using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class DimentionsPolicyBuilderTests
    {
        [Fact]
        public void CreatesCorrectSimpleDimentionsPolicy()
        {
            var dimention1Name = "foo";
            var dimention1Value = "foo-value";
            var dimention2Name = "bar";
            var dimention2Value = "bar-value";
            var sectionPolicy =
                new EmitMetricPolicyBuilder()
                    .SetDimention(dimention1Name, dimention1Value)
                    .SetDimention(dimention2Name, dimention2Value)
                    .Create();

            var xml = ((SectionPolicy)sectionPolicy).GetXml().ToString();
            xml.Should().Be(
$@"<root>
  <dimention name=""{dimention1Name}"" value=""{dimention1Value}""/>
  <dimention name=""{dimention2Name}"" value=""{dimention2Value}""/>
</root>");
        }

//        public void CreatesCorrectPolicy()
//        {
//            var policyName = "policy-name";
//            var policyValue = "policy-value";
//            var policyNamespace = "policy-namespace";
//            var dimention1Name = "foo";
//            var dimention1Value = "foo-value";
//            var dimention2Name = "bar";
//            var dimention2Value = "bar-value";
//            var sectionPolicy =
//                new DimentionsPolicyBuilder(new EmitMetricPolicyBuilder(policyName, policyValue, policyNamespace))
//                    .SetDimention(dimention1Name, dimention1Value)
//                    .SetDimention(dimention2Name, dimention2Value)
//                    .Create();

//            var xml = ((SectionPolicy)sectionPolicy).GetXml().ToString();
//            xml.Should().Be(
//    $@"<required-claims>
//  <claim name=""{claim1}"" match=""{claim1Match.ToString().ToLower()}"" separator=""{claim1Separator}"">
//    <value>{claim1Value1}</value>
//    <value>{claim1Value2}</value>
//  </claim>
//  <claim name=""{claim2}"" match=""{claim2Match.ToString().ToLower()}"" separator=""{claim2Separator}"">
//    <value>{claim2Value1}</value>
//    <value>{claim2Value2}</value>
//  </claim>
//</required-claims>");
            
//            }
    }
}
