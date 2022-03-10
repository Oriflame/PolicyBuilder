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
        [InlineData(false, false, "@(context.Request.Body.As<JObject>())")]
        [InlineData(true, true, "context.Request.Body.As<JObject>(preserveContent: true)")]
        public void GetBodyAsJObjectGeneratesCorrectPolicy(bool inline, bool preserveContent, string expected)
        {
            var policy = ContextRequest.GetBodyAsJObject(inline, preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, true, "@(context.Request.Body.As<string>(preserveContent: true))")]
        [InlineData(true, false, "context.Request.Body.As<string>()")]
        public void GetBodyAsStringGeneratesCorrectPolicy(bool inline, bool preserveContent, string expected)
        {
            var policy = ContextRequest.GetBodyAsString(inline, preserveContent);
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

        [Theory]
        [InlineData("testingParam", "TestDefault", false, "@(context.Request.OriginalUrl.Query.GetValueOrDefault(\"testingParam\", \"TestDefault\"))")]
        [InlineData("testingParam", "TestDefault", true, "context.Request.OriginalUrl.Query.GetValueOrDefault(\"testingParam\", \"TestDefault\")")]
        [InlineData("testingParam", null, true, "context.Request.OriginalUrl.Query.GetValueOrDefault(\"testingParam\")")]
        public void GetQueryParamGeneratesCorrectPolicy(string paramName,string defaultValue, bool inline, string expected)
        {
            var policy = ContextRequest.GetQueryParam(paramName, defaultValue, inline);
            policy.Should().Be(expected);
        }
    }
}
