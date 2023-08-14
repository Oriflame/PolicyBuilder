using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;
using Oriflame.PolicyBuilder.Xml.Providers;
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
            var policy = GetVariableValue(variableName, strict).GetPropertyPath();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", true, false, "context.Variables.GetValueOrDefault(\"testingVariable\", true)")]
        [InlineData("testingVariable", true, true, "((System.Boolean)context.Variables.GetValueOrDefault(\"testingVariable\", true))")]
        [InlineData("testingVariable", 123, true, "((System.Int32)context.Variables.GetValueOrDefault(\"testingVariable\", 123))")]
        [InlineData("testingVariable", 123.1f, true, "((System.Single)context.Variables.GetValueOrDefault(\"testingVariable\", 123.1))")]
        [InlineData("testingVariable", 123.1d, true, "((System.Double)context.Variables.GetValueOrDefault(\"testingVariable\", 123.1))")]
        [InlineData("testingVariable", "Value", true, "((System.String)context.Variables.GetValueOrDefault(\"testingVariable\", \"Value\"))")]
        public void GetValueOrDefaultGeneratesCorrectPolicy(string variableName, dynamic value, bool explicitCast, string expected)
        {
            var policy = ContextProvider.Context.Variables.GetValueOrDefault(variableName, value, explicitCast);
            Assert.Equal(expected, policy);
        }

        [Theory]
        [InlineData("testingVariable", "((IResponse)context.Variables[\"testingVariable\"]).Body")]
        public void GetBodyGeneratesCorrectPolicy(string variableName, string expected)
        {
            var policy = ContextProvider.Context.Variables.Get(variableName).Body.GetPropertyPath();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, "((string)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, "((string)context.Variables[\"testingVariable\"])")]
        public void GetAsStringGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = GetVariableValue(variableName, strict).AsString();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, "((IResponse)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, "((IResponse)context.Variables[\"testingVariable\"])")]
        public void GetAsResponseGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = GetVariableValue(variableName, strict).AsResponse().GetPropertyPath();
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", "((IResponse)context.Variables[\"testingVariable\"]).StatusCode")]
        public void GetStatusCodeGeneratesCorrectPolicy(string variableName, string expected)
        {
            var policy = GetVariableValue(variableName).AsResponse().StatusCode;
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", "((IResponse)context.Variables[\"testingVariable\"]).StatusReason")]
        public void GetStatusReasonGeneratesCorrectPolicy(string variableName, string expected)
        {
            var policy = GetVariableValue(variableName).AsResponse().StatusReason;
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", false, "((bool)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, "((bool)context.Variables[\"testingVariable\"])")]
        public void GetAsBooleanGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = GetVariableValue(variableName, strict).AsBoolean();
            policy.Should().Be(expected);
        }


        [Theory]
        [InlineData("testingVariable", false, "((JObject)context.Variables.GetValueOrDefault(\"testingVariable\"))")]
        [InlineData("testingVariable", true, "((JObject)context.Variables[\"testingVariable\"])")]
        public void GetAsJObjectGeneratesCorrectPolicy(string variableName, bool strict, string expected)
        {
            var policy = GetVariableValue(variableName, strict).AsJObject();
            policy.Should().Be(expected);
        }

        //[Theory]
        //[InlineData("testingVariable", false, false, "@((((IResponse)context.Variables[\"testingVariable\"]).Body.As<string>()))")]
        //[InlineData("testingVariable", true, true, "(((IResponse)context.Variables[\"testingVariable\"]).Body.As<string>(preserveContent: true))")]
        //public void GetBodyAsStringGeneratesCorrectPolicy(string variableName, bool strict, bool preserveContent, string expected)
        //{
        //    var policy = ContextProvider.Context.Variables.GetBodyAsString(variableName, strict, preserveContent);
        //    policy.Should().Be(expected);
        //}

        [Theory]
        [InlineData("testingVariable", false, "((IResponse)context.Variables[\"testingVariable\"]).Body.As<JObject>()")]
        [InlineData("testingVariable", true, "((IResponse)context.Variables[\"testingVariable\"]).Body.As<JObject>(preserveContent: true)")]
        public void GetBodyAsJObjectGeneratesCorrectPolicy(string variableName, bool preserveContent, string expected)
        {
            var policy = ContextProvider.Context.Variables.Get(variableName).Body.AsJObject(preserveContent);
            policy.Should().Be(expected);
        }

        [Theory]
        [InlineData("testingVariable", "context.Variables.ContainsKey(\"testingVariable\")")]
        public void ContainsGeneratesCorrectPolicy(string variableName, string expected)
        {
            var policy = ContextProvider.Context.Variables.ContainsKey(variableName);
            policy.Should().Be(expected);
        }

        private static IVariable GetVariableValue(string variableName, bool strict = true)
        {
            return strict
                ? ContextProvider.Context.Variables.Get(variableName)
                : ContextProvider.Context.Variables.GetValueOrDefault(variableName);
        }
    }
}
