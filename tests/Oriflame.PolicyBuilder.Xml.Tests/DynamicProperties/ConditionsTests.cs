using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.DynamicProperties
{
    public class ConditionsTests
    {
        [Theory]
        [InlineData("testVariable", false, "(string.IsNullOrEmpty((string)context.Variables.GetValueOrDefault(\"testVariable\")))")]
        [InlineData("testVariable", true, "(string.IsNullOrEmpty((string)context.Variables[\"testVariable\"]))")]
        public void IsNullOrEmptyGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = Conditions.IsNullOrEmpty(variableName, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, "(context.Variables.GetValueOrDefault(\"testVariable\") == null)")]
        [InlineData("testVariable", true, "(context.Variables[\"testVariable\"] == null)")]
        public void IsNullGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = Conditions.IsNull(variableName, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, "(context.Variables.GetValueOrDefault(\"testVariable\") != null)")]
        [InlineData("testVariable", true, "(context.Variables[\"testVariable\"] != null)")]
        public void IsNotNullGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = Conditions.IsNotNull(variableName, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("string.IsNullOrEmpty(context.Request.Body.As<string>(preserveContent: true))")]
        public void IsRequestBodyNullGeneratesCorrectPolicy(string expected)
        {
            var policy = Conditions.IsRequestBodyNull();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, "(((IResponse)context.Variables.GetValueOrDefault(\"testVariable\")).StatusCode.ToString().StartsWith(\"2\"))")]
        [InlineData("testVariable", true, "(((IResponse)context.Variables[\"testVariable\"]).StatusCode.ToString().StartsWith(\"2\"))")]
        public void IsResponseCodeOkGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = Conditions.IsResponseCodeOk(variableName, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, "(!((IResponse)context.Variables.GetValueOrDefault(\"testVariable\")).StatusCode.ToString().StartsWith(\"2\"))")]
        [InlineData("testVariable", true, "(!((IResponse)context.Variables[\"testVariable\"]).StatusCode.ToString().StartsWith(\"2\"))")]
        public void IsResponseCodeNotOkGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = Conditions.IsResponseCodeNotOk(variableName, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, "(context.Variables.GetValueOrDefault(\"testVariable\") == null)")]
        [InlineData("testVariable", true, "(context.Variables[\"testVariable\"] == null)")]
        public void IsResponseNullGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = Conditions.IsResponseNull(variableName, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, "(context.Variables.GetValueOrDefault(\"testVariable\") != null)")]
        [InlineData("testVariable", true, "(context.Variables[\"testVariable\"] != null)")]
        public void IsResponseNotNullGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = Conditions.IsResponseNotNull(variableName, strict);
            policy.Should().Be(expected);
        }
    }
}
