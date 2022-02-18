using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.DynamicProperties
{
    public class ContextVariableTests
    {
        [Theory]
        [InlineData("testingVariable", false, "context.Variables.GetValueOrDefault(\"testingVariable\")")]
        [InlineData("testingVariable", true, "context.Variables[\"testingVariable\"]")]
        public void GetGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = ContextVariable.Get(variableName, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", "((IResponse)context.Variables[\"testingVariable\"]).Body")]
        public void GetBodyGeneratesCorrectPolicy(string variableName, string expected)
        {
            var policy = ContextVariable.GetBody(variableName);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, false, "@((string)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, false, "@((string)context.Variables[\"testingVariable\"])")]
        [InlineData("testingVariable", false, true, "((string)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, true, "((string)context.Variables[\"testingVariable\"])")]
        public void GetAsStringGeneratesCorrectPolicy(string variableName, bool strict, bool inline, string expected)
        {
            var policy = ContextVariable.GetAsString(variableName, strict, inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, "((IResponse)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, "((IResponse)context.Variables[\"testingVariable\"])")]
        public void GetAsResponseGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = ContextVariable.GetAsResponse(variableName, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, "@(((IResponse)context.Variables[\"testingVariable\"]).StatusCode)")]
        [InlineData("testingVariable", true, "(((IResponse)context.Variables[\"testingVariable\"]).StatusCode)")]
        public void GetStatusCodeGeneratesCorrectPolicy(string variableName, bool inline, string expected)
        {
            var policy = ContextVariable.GetStatusCode(variableName, inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, "@(((IResponse)context.Variables[\"testingVariable\"]).StatusReason)")]
        [InlineData("testingVariable", true, "(((IResponse)context.Variables[\"testingVariable\"]).StatusReason)")]
        public void GetStatusReasonGeneratesCorrectPolicy(string variableName, bool inline, string expected)
        {
            var policy = ContextVariable.GetStatusReason(variableName, inline);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, false, "@((bool)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, false, "@((bool)context.Variables[\"testingVariable\"])")]
        [InlineData("testingVariable", false, true, "((bool)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, true, "((bool)context.Variables[\"testingVariable\"])")]
        public void GetAsBooleanGeneratesCorrectPolicy(string variableName, bool strict, bool inline, string expected)
        {
            var policy = ContextVariable.GetAsBoolean(variableName, strict, inline);
            policy.Should().Be(expected);
        }

        
        [Theory]
        [InlineData("testingVariable", false, "((JObject)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, "((JObject)context.Variables[\"testingVariable\"])")]
        public void GetAsJObjectGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = ContextVariable.GetAsJObject(variableName, strict);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, false, "@(((IResponse)context.Variables[\"testingVariable\"]).Body.As<string>(preserveContent: false))")]
        [InlineData("testingVariable", true, true, "(((IResponse)context.Variables[\"testingVariable\"]).Body.As<string>(preserveContent: true))")]
        public void GetBodyAsStringGeneratesCorrectPolicy(string variableName, bool strict, bool preserveContent, string expected)
        {
            var policy = ContextVariable.GetBodyAsString(variableName, strict, preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, "(((IResponse)context.Variables[\"testingVariable\"]).Body.As<JObject>(preserveContent: false))")]
        [InlineData("testingVariable", true, "(((IResponse)context.Variables[\"testingVariable\"]).Body.As<JObject>(preserveContent: true))")]
        public void GetBodyAsJObjectGeneratesCorrectPolicy(string variableName, bool preserveContent, string expected)
        {
            var policy = ContextVariable.GetBodyAsJObject(variableName, preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", "context.Variables.ContainsKey(\"testingVariable\")")]
        public void ContainsGeneratesCorrectPolicy(string variableName, string expected)
        {
            var policy = ContextVariable.Contains(variableName);
            policy.Should().Be(expected);
        }
    }
}
