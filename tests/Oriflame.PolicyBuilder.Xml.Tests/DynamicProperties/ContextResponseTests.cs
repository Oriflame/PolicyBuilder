using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.DynamicProperties
{
    public class ContextResponseTests
    {
        [Theory]
        [InlineData(false, "@((IResponse)context.Response)")]
        [InlineData(true, "((IResponse)context.Response)")]
        public void GetGeneratesCorrectPolicy(bool inline, string expected)
        {
            var policy = ContextResponse.Get(inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, false, "@(context.Response.Body.As<JObject>())")]
        [InlineData(true, true, "context.Response.Body.As<JObject>(preserveContent: true)")]
        public void GetBodyAsJObjectGeneratesCorrectPolicy(bool inline, bool preserveContent, string expected)
        {
            var policy = ContextResponse.GetBodyAsJObject(inline, preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, false, "@(context.Response.Body.As<string>())")]
        [InlineData(true, false, "context.Response.Body.As<string>()")]
        [InlineData(false, true, "@(context.Response.Body.As<string>(preserveContent: true))")]
        [InlineData(true, true, "context.Response.Body.As<string>(preserveContent: true)")]
        public void GetBodyAsStringGeneratesCorrectPolicy(bool inline, bool preserveContent, string expected)
        {
            var policy = ContextResponse.GetBodyAsString(inline, preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "@(((IResponse)context.Response).StatusCode)")]
        [InlineData(true, "((IResponse)context.Response).StatusCode")]
        public void GetStatusCodeGeneratesCorrectPolicy(bool inline, string expected)
        {
            var policy = ContextResponse.GetStatusCode(inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "@(((IResponse)context.Response).StatusReason)")]
        [InlineData(true, "((IResponse)context.Response).StatusReason")]
        public void GetStatusReasonGeneratesCorrectPolicy(bool inline, string expected)
        {
            var policy = ContextResponse.GetStatusReason(inline);
            policy.Should().Be(expected);
        }
    }
}
