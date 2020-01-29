using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.DynamicProperties
{
    public class ContextRequestTests
    {
        [Theory]
        [InlineData(false, "@(context.Request)")]
        [InlineData(true, "context.Request")]
        public void GetGeneratesCorrectPolicy(bool inline, string expected)
        {
            var policy = ContextRequest.Get(inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "@(context.Request.Body)")]
        [InlineData(true, "context.Request.Body")]
        public void GetBodyGeneratesCorrectPolicy(bool inline, string expected)
        {
            var policy = ContextRequest.GetBody(inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "@(context.Request.Body.As<JObject>())")]
        [InlineData(true, "context.Request.Body.As<JObject>()")]
        public void GetBodyAsJObjectGeneratesCorrectPolicy(bool inline, string expected)
        {
            var policy = ContextRequest.GetBodyAsJObject(inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "@(context.Request.Body.As<string>(true))")]
        [InlineData(true, "context.Request.Body.As<string>(true)")]
        public void GetBodyAsStringGeneratesCorrectPolicy(bool inline, string expected)
        {
            var policy = ContextRequest.GetBodyAsString(inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingParam", false, "@(context.Request.MatchedParameters[\"testingParam\"])")]
        [InlineData("testingParam", true, "context.Request.MatchedParameters[\"testingParam\"]")]
        public void GetRouteParamGeneratesCorrectPolicy(string paramName, bool inline, string expected)
        {
            var policy = ContextRequest.GetRouteParam(paramName, inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingParam", false, "@((string)context.Request.MatchedParameters[\"testingParam\"])")]
        [InlineData("testingParam", true, "(string)context.Request.MatchedParameters[\"testingParam\"]")]
        public void GetRouteParamAsStringGeneratesCorrectPolicy(string paramName, bool inline, string expected)
        {
            var policy = ContextRequest.GetRouteParamAsString(paramName, inline);
            policy.Should().Be(expected);
        }
    }
}
