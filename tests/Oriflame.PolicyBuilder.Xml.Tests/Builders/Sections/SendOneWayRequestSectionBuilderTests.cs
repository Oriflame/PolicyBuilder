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
    public class SendOneWayRequestSectionBuilderTests
    {
        [Theory]
        [InlineData(RequestMode.Copy, "OK", "https://test.com", "thumbprint")]
        public void CreatesCorrectPolicy(RequestMode mode, string body, string url, string thumbprint)
        {
            var header = new { Name = "header-name1", Value = "header-value1", ExistsAction = ExistsAction.Append };
            var method = HttpMethod.Get;

            var attributes = 
                new SendOneWayRequestAttributesBuilder()
                    .Mode(mode)
                    .Create();

            var basePolicy = (SectionPolicy) 
                new SendOneWayRequestSectionBuilder(attributes)
                    .SetBody(body)
                    .SetUrl(url)
                    .SetMethod(method)
                    .SetHeader(header.Name, header.Value, header.ExistsAction)
                    .AuthenticationCertificate(thumbprint)
                    .Create();
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
$@"<send-one-way-request mode=""{RequestModeMapper.Map(mode)}"">
  <set-body>{body}</set-body>
  <set-url>{url}</set-url>
  <set-method>{method.ToString().ToUpper()}</set-method>
  <set-header name=""{header.Name}"" exists-action=""{header.ExistsAction.ToString().ToLower()}"">
    <value>{header.Value}</value>
  </set-header>
  <authentication-certificate thumbprint=""{thumbprint}"" />
</send-one-way-request>");
        }
    }
}
