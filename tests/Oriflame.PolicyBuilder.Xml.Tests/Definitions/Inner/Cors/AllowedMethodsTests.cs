using System.Net.Http;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner.Cors;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner.Cors
{
    public class AllowedMethodsTests
    {
        [Theory]
        [InlineData("GET", "POST", 5)]
        public void CreatesCorrectPolicy(string httpMethod1, string httpMethod2, int preflightRequest)
        {
            var basePolicy = new AllowedMethods(new []{ new HttpMethod(httpMethod1), new HttpMethod(httpMethod2)}, preflightRequest);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                @$"<allowed-methods preflight-result-max-age=""{preflightRequest}"">
  <method>{httpMethod1}</method>
  <method>{httpMethod2}</method>
</allowed-methods>");
        }
    }
}