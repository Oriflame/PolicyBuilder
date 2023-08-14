using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Providers;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.DynamicProperties
{
    public class RequestTests
    {
        [Theory]
        [InlineData("context.Request")]
        public void GetGeneratesCorrectPolicy(string expected)
        {
            var policy = ContextProvider.Context.Request.GetPropertyPath();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("context.Request.Body")]
        public void GetBodyGeneratesCorrectPolicy(string expected)
        {
            var policy = ContextProvider.Context.Request.Body.GetPropertyPath();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "context.Request.Body.As<JObject>()")]
        [InlineData(true, "context.Request.Body.As<JObject>(preserveContent: true)")]
        public void GetBodyAsJObjectGeneratesCorrectPolicy(bool preserveContent, string expected)
        {
            var policy = ContextProvider.Context.Request.Body.AsJObject(preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "context.Request.Body.As<string>(preserveContent: true)")]
        [InlineData(false, "context.Request.Body.As<string>()")]
        public void GetBodyAsStringGeneratesCorrectPolicy(bool preserveContent, string expected)
        {
            var policy = ContextProvider.Context.Request.Body.AsString(preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "context.Request.Body.As<JArray>()")]
        [InlineData(true, "context.Request.Body.As<JArray>(preserveContent: true)")]
        public void GetBodyAsJArrayGeneratesCorrectPolicy(bool preserveContent, string expected)
        {
            var policy = ContextProvider.Context.Request.Body.AsJArray(preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingParam", "context.Request.MatchedParameters[\"testingParam\"]")]
        public void GetRouteParamGeneratesCorrectPolicy(string paramName, string expected)
        {
            var policy = ContextProvider.Context.Request.MatchedParameters.Get(paramName).ToString();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingParam", "(string)context.Request.MatchedParameters[\"testingParam\"]")]
        public void GetRouteParamAsStringGeneratesCorrectPolicy(string paramName, string expected)
        {
            var policy = ContextProvider.Context.Request.MatchedParameters.Get(paramName).AsString();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingParam", "TestDefault", "context.Request.OriginalUrl.Query.GetValueOrDefault(\"testingParam\", \"TestDefault\")")]
        [InlineData("testingParam", null, "context.Request.OriginalUrl.Query.GetValueOrDefault(\"testingParam\")")]
        public void GetQueryParamGeneratesCorrectPolicy(string paramName, string defaultValue, string expected)
        {
            var policy = ContextProvider.Context.Request.OriginalUrl.Query.GetValueOrDefault(paramName, defaultValue).ToString();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingParam", "TestDefault", "context.Request.Headers.GetValueOrDefault(\"testingParam\", \"TestDefault\")")]
        [InlineData("testingParam", null, "context.Request.Headers.GetValueOrDefault(\"testingParam\")")]
        public void GetHeaderParamGeneratesCorrectPolicy(string paramName, string defaultValue, string expected)
        {
            var policy = ContextProvider.Context.Request.Headers.GetValueOrDefault(paramName, defaultValue).ToString();
            policy.Should().Be(expected);
        }
    }
}
