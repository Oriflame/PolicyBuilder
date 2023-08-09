using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class ReturnResponseSectionBuilderTests
    {
        [Theory]
        [InlineData("OK", "200", "Success")]
        public void CreatesCorrectPolicy(string body, string statusCode, string reason)
        {
            var header = new { Name = "header-name1", Value = "header-value1", ExistsAction = ExistsAction.Append };
            var sectionPolicy = 
                new ReturnResponseSectionBuilder()
                    .SetBody(body)
                    .SetStatus(statusCode, reason)
                    .SetHeader(header.Name, header.Value, header.ExistsAction)
                    .Create();

            var xml = ((SectionPolicy)sectionPolicy).GetXml().ToString();
            xml.Should().Be(
$@"<return-response>
  <set-status code=""{statusCode}"" reason=""{reason}"" />
  <set-header name=""{header.Name}"" exists-action=""{header.ExistsAction.ToString().ToLower()}"">
    <value>{header.Value}</value>
  </set-header>
  <set-body>{body}</set-body>
</return-response>");
        }
    }
}