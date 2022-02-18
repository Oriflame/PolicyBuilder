using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.DynamicProperties
{
    public class ConditionsTests
    {
        [Theory]
        [InlineData("testVariable", false, false, "@(string.IsNullOrEmpty((string)context.Variables.GetValueOrDefault(\"testVariable\")))")]
        [InlineData("testVariable", true, true, "(string.IsNullOrEmpty((string)context.Variables[\"testVariable\"]))")]
        [InlineData("testVariable", true, false, "(string.IsNullOrEmpty((string)context.Variables.GetValueOrDefault(\"testVariable\")))")]
        [InlineData("testVariable", false, true, "@(string.IsNullOrEmpty((string)context.Variables[\"testVariable\"]))")]
        public void IsNullOrEmptyGeneratesCorrectPolicy(string variableName, bool inline, bool strict, string expected)
        {
            var policy = Conditions.IsNullOrEmpty(variableName, inline, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, false, "@(context.Variables.GetValueOrDefault(\"testVariable\") == null)")]
        [InlineData("testVariable", true, true, "(context.Variables[\"testVariable\"] == null)")]
        [InlineData("testVariable", true, false, "(context.Variables.GetValueOrDefault(\"testVariable\") == null)")]
        [InlineData("testVariable", false, true, "@(context.Variables[\"testVariable\"] == null)")]
        public void IsNullGeneratesCorrectPolicy(string variableName, bool inline, bool strict, string expected)
        {
            var policy = Conditions.IsNull(variableName, inline, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, false, "@(context.Variables.GetValueOrDefault(\"testVariable\") != null)")]
        [InlineData("testVariable", true, true, "(context.Variables[\"testVariable\"] != null)")]
        [InlineData("testVariable", true, false, "(context.Variables.GetValueOrDefault(\"testVariable\") != null)")]
        [InlineData("testVariable", false, true, "@(context.Variables[\"testVariable\"] != null)")]
        public void IsNotNullGeneratesCorrectPolicy(string variableName, bool inline, bool strict, string expected)
        {
            var policy = Conditions.IsNotNull(variableName, inline, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData(false, "@(string.IsNullOrEmpty(context.Request.Body.As<string>(preserveContent: true)))")]
        [InlineData(true, "string.IsNullOrEmpty(context.Request.Body.As<string>(preserveContent: true))")]
        public void IsRequestBodyNullGeneratesCorrectPolicy(bool inline, string expected)
        {
            var policy = Conditions.IsRequestBodyNull(inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, false, "@(((IResponse)context.Variables.GetValueOrDefault(\"testVariable\")).StatusCode.ToString().StartsWith(\"2\"))")]
        [InlineData("testVariable", true, true, "(((IResponse)context.Variables[\"testVariable\"]).StatusCode.ToString().StartsWith(\"2\"))")]
        [InlineData("testVariable", true, false, "(((IResponse)context.Variables.GetValueOrDefault(\"testVariable\")).StatusCode.ToString().StartsWith(\"2\"))")]
        [InlineData("testVariable", false, true, "@(((IResponse)context.Variables[\"testVariable\"]).StatusCode.ToString().StartsWith(\"2\"))")]
        public void IsResponseCodeOkGeneratesCorrectPolicy(string variableName, bool inline, bool strict, string expected)
        {
            var policy = Conditions.IsResponseCodeOk(variableName, inline, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, false, "@(!((IResponse)context.Variables.GetValueOrDefault(\"testVariable\")).StatusCode.ToString().StartsWith(\"2\"))")]
        [InlineData("testVariable", true, true, "(!((IResponse)context.Variables[\"testVariable\"]).StatusCode.ToString().StartsWith(\"2\"))")]
        [InlineData("testVariable", true, false, "(!((IResponse)context.Variables.GetValueOrDefault(\"testVariable\")).StatusCode.ToString().StartsWith(\"2\"))")]
        [InlineData("testVariable", false, true, "@(!((IResponse)context.Variables[\"testVariable\"]).StatusCode.ToString().StartsWith(\"2\"))")]
        public void IsResponseCodeNotOkGeneratesCorrectPolicy(string variableName, bool inline, bool strict, string expected)
        {
            var policy = Conditions.IsResponseCodeNotOk(variableName, inline, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, false, "@(context.Variables.GetValueOrDefault(\"testVariable\") == null)")]
        [InlineData("testVariable", true, true, "(context.Variables[\"testVariable\"] == null)")]
        [InlineData("testVariable", true, false, "(context.Variables.GetValueOrDefault(\"testVariable\") == null)")]
        [InlineData("testVariable", false, true, "@(context.Variables[\"testVariable\"] == null)")]
        public void IsResponseNullGeneratesCorrectPolicy(string variableName, bool inline, bool strict, string expected)
        {
            var policy = Conditions.IsResponseNull(variableName, inline, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testVariable", false, false, "@(context.Variables.GetValueOrDefault(\"testVariable\") != null)")]
        [InlineData("testVariable", true, true, "(context.Variables[\"testVariable\"] != null)")]
        [InlineData("testVariable", true, false, "(context.Variables.GetValueOrDefault(\"testVariable\") != null)")]
        [InlineData("testVariable", false, true, "@(context.Variables[\"testVariable\"] != null)")]
        public void IsResponseNotNullGeneratesCorrectPolicy(string variableName, bool inline, bool strict, string expected)
        {
            var policy = Conditions.IsResponseNotNull(variableName, inline, strict);
            policy.Should().Be(expected);
        }
    }
}
