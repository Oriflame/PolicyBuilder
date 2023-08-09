using System;
using System.Net.Http;
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
        [InlineData(false, RequestMode.Copy, "responseVariableName", 5, "OK", "https://test.com")]
        public void CreatesCorrectPolicy(bool ignoreError, RequestMode mode, string responseVariable, int timeout,
            string body, string url)
        {
            var method = HttpMethod.Get;
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
  <set-url>{url}</set-url>
  <set-body>{body}</set-body>
</send-request>");
        }

        [Theory]
        [InlineData(false, RequestMode.Copy, "responseVariableName", 5, "OK", "https://test.com", "thumbprint")]
        public void CreatesCorrectFullPolicy(bool ignoreError, RequestMode mode, string responseVariable, int timeout,
            string body, string url, string thumbprint)
        {
            var header = new { Name = "header-name1", Value = "header-value1", ExistsAction = ExistsAction.Append };
            var method = HttpMethod.Get;

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
                    .SetMethod(method)
                    .SetHeader(header.Name, header.Value, header.ExistsAction)
                    .AuthenticationCertificate(thumbprint)
                    .Create();
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
$@"<send-request ignore-error=""{ (ignoreError ? "true" : "false")}"" mode=""{RequestModeMapper.Map(mode)}"" response-variable-name=""{responseVariable}"" timeout=""{timeout}"">
  <set-url>{url}</set-url>
  <set-method>{method.ToString().ToUpper()}</set-method>
  <set-header name=""{header.Name}"" exists-action=""{header.ExistsAction.ToString().ToLower()}"">
    <value>{header.Value}</value>
  </set-header>
  <set-body>{body}</set-body>
  <authentication-certificate thumbprint=""{thumbprint}"" />
</send-request>");
        }
    }
}
