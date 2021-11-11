using System;
using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Oriflame.PolicyBuilder.Xml.Mappers;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class SendRequestSectionBuilderTests
    {
        [Theory]
        [InlineData(false, RequestMode.New, "responseVariableName", 5, "OK", "https://test.com")]
        public void CreatesCorrectPolicy(bool ignoreError, RequestMode mode, string responseVariable, int timeout,
            string body, string url)
        {
            var attributes = 
                new SendRequestAttributesBuilder()
                    .IgnoreError(ignoreError)
                    .Mode(mode)
                    .ResponseVariable(responseVariable)
                    .Timeout(TimeSpan.FromSeconds(timeout))
                    .Create();

            var basePolicy = (SectionPolicy) 
                new SendRequestSectionBuilder(attributes)
                    .SetBody(body)
                    .SetUrl(url)
                    .Create();
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
$@"<send-request ignore-error=""{ (ignoreError ? "true" : "false")}"" mode=""{RequestModeMapper.Map(mode)}"" response-variable-name=""{responseVariable}"" timeout=""{timeout}"">
  <set-body>{body}</set-body>
  <set-url>{url}</set-url>
</send-request>");
        }
    }
}
