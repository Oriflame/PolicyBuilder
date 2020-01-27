using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Mappers;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class SetHeaderParameterTests
    {
        [Theory]
        [InlineData("x-custom-context", "customContext", ExistsAction.Append)]
        public void CreatesCorrectPolicy(string headerName, string headerValue, ExistsAction existsAction)
        {
            var basePolicy = new SetHeaderParameter(headerName, headerValue, existsAction);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                $@"<set-header name=""{headerName}"" exists-action=""{ExistsActionMapper.Map(existsAction)}"">
  <value>{headerValue}</value>
</set-header>"
            );
        }
    }
}