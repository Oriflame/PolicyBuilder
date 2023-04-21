using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Mappers;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class SetQueryParameterTests
    {
        [Theory]
        [InlineData("customParameter", "parameterValue", ExistsAction.Append)]
        public void CreatesCorrectPolicy(string parameterName, string parameterValue, ExistsAction existsAction)
        {
            var basePolicy = new SetQueryParameter(parameterName, parameterValue, existsAction);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                $@"<set-query-parameter name=""{parameterName}"" exists-action=""{ExistsActionMapper.Map(existsAction)}"">
  <value>{parameterValue}</value>
</set-query-parameter>");
        }
    }
}