using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Providers;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.DynamicProperties
{
    public class ContextResponseTests
    {
        [Theory]
        [InlineData("context.Response")]
        public void GetGeneratesCorrectPolicy(string expected)
        {
            var policy = ContextProvider.Context.Response.Get();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "context.Response.Body.As<JObject>()")]
        [InlineData(true, "context.Response.Body.As<JObject>(preserveContent: true)")]
        public void GetBodyAsJObjectGeneratesCorrectPolicy(bool preserveContent, string expected)
        {
            var policy = ContextProvider.Context.Response.Body.GetAsJObject(preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "context.Response.Body.As<string>()")]
        [InlineData(true, "context.Response.Body.As<string>(preserveContent: true)")]
        public void GetBodyAsStringGeneratesCorrectPolicy(bool preserveContent, string expected)
        {
            var policy = ContextProvider.Context.Response.Body.GetAsString(preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "context.Response.Body.As<JArray>()")]
        [InlineData(true, "context.Response.Body.As<JArray>(preserveContent: true)")]
        public void GetBodyAsJArrayGeneratesCorrectPolicy(bool preserveContent, string expected)
        {
            var policy = ContextProvider.Context.Response.Body.GetAsJArray(preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("context.Response.StatusCode")]
        public void GetStatusCodeGeneratesCorrectPolicy(string expected)
        {
            var policy = ContextProvider.Context.Response.StatusCode;
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("context.Response.StatusReason")]
        public void GetStatusReasonGeneratesCorrectPolicy(string expected)
        {
            var policy = ContextProvider.Context.Response.StatusReason;
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingParam", "TestDefault", @"context.Response.Headers.GetValueOrDefault(""testingParam"", ""TestDefault"")")]
        [InlineData("testingParam", null, @"context.Response.Headers.GetValueOrDefault(""testingParam"")")]
        public void GetHeaderParamGeneratesCorrectPolicy(string paramName, string defaultValue, string expected)
        {
            var policy = ContextProvider.Context.Response.Headers.GetParam(paramName, defaultValue);
            policy.Should().Be(expected);
        }
    }
}
