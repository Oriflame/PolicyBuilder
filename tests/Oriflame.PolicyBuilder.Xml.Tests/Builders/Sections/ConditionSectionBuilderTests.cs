using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class ConditionSectionBuilderTests
    {
        [Theory]
        [InlineData("@(0 == 1)", "trueCondition", "falseCondition")]
        public void CreatesCorrectPolicy(string condition, string trueConditionComment, string falseConditionComment)
        {
            var conditionPolicy = (SectionPolicy) 
                new InboundConditionSectionBuilder()
                    .When(condition, a => 
                        a.Comment(trueConditionComment).Create())
                    .Otherwise(a => 
                        a.Comment(falseConditionComment).Create());
           
            
            var xml = conditionPolicy.GetXml().ToString();
            xml.Should().Be(
$@"<choose>
  <when condition=""{condition}"">
    <!-- {trueConditionComment} -->
  </when>
  <otherwise>
    <!-- {falseConditionComment} -->
  </otherwise>
</choose>");
        }
    }
}