using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class SetVariablePolicyTests
    {
        [Theory]
        [InlineData("customParameter", "parameterValue")]
        public void CreatesCorrectPolicy(string variableName, string parameterValue)
        {
            var basePolicy = new SetVariablePolicy(variableName, parameterValue);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<set-variable name=\"{variableName}\" value=\"{parameterValue}\" />");
        }
    }
}