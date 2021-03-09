using FluentAssertions;
using Oriflame.PolicyBuilder.Generator.Services;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Policies
{
    public class PolicyXmlExporterTest
    {
        [Fact]
        public void ExportToFileShouldPrettifyCodeTest()
        {
            // Arrange
            var inputXml = GetInputXml();
			var underTest = new XmlInnerCodePrettifyService();

			// Act
			var outputXml = underTest.PrettifyContent(inputXml);

            // Assert
            outputXml.Should().Be(outputXml);
        }

        private string GetInputXml()
        {
            return
@"<policies>
	<inbound>
		<base />
		<validate-jwt header-name=""Authorization"" failed-validation-httpcode=""401"" failed-validation-error-message=""Unauthorized. Access token is missing or invalid."">
			<openid-config url=""http://contoso.com/.well-known/openid-configuration"" />
			<issuers>
				<issuer>@{
                                if (true &amp;&amp; true) return ""http://contoso.com/"";
                                else return ""http://contoso.com/"";
                            }</issuer>
			</issuers>
			<required-claims>
				<claim name=""scope"" match=""all"" separator="""">
					<value>forcast_api</value>
				</claim>
			</required-claims>
		</validate-jwt>
		<set-variable name=""ReportingUrl"" value=""@{&#xD;&#xA;                            var serviceType = &quot;Reporting&quot;;&#xD;&#xA;                            var uriJson = ((JObject)context.Variables[&quot;UriSettingsJObject&quot;]);&#xD;&#xA;                            if (uriJson != null &amp;&amp; uriJson[serviceType] != null)&#xD;&#xA;                            {&#xD;&#xA;                                return uriJson[serviceType][&quot;InternalUrl&quot;].ToString();&#xD;&#xA;                            }&#xD;&#xA;                            return null;&#xD;&#xA;                        }"" />
	</inbound>
	<backend>
		<base />
	</backend>
	<outbound>
		<base />
	</outbound>
	<on-error />
</policies>";
        }

        private string GetOutputXml()
        {
            return
@"<policies>
	<inbound>
		<base />
		<validate-jwt header-name=""Authorization"" failed-validation-httpcode=""401"" failed-validation-error-message=""Unauthorized. Access token is missing or invalid."">
			<openid-config url=""http://contoso.com/.well-known/openid-configuration"" />
			<issuers>
				<issuer>@{
                                if (true && true) return ""http://contoso.com/"";
                                else return ""http://contoso.com/"";
                            }</issuer>
			</issuers>
			<required-claims>
				<claim name=""scope"" match=""all"" separator="""">
					<value>forcast_api</value>
				</claim>
			</required-claims>
		</validate-jwt>
		<set-variable name=""ReportingUrl"" value=""@{
                            var serviceType = ""Reporting"";
                            var uriJson = ((JObject)context.Variables[""UriSettingsJObject""]);
                            if (uriJson != null && uriJson[serviceType] != null)
                            {
                                return uriJson[serviceType][""InternalUrl""].ToString();
                            }
                            return null;
                        }"" />
	</inbound>
	<backend>
		<base />
	</backend>
	<outbound>
		<base />
	</outbound>
	<on-error />
</policies>";
        }
    }
}
