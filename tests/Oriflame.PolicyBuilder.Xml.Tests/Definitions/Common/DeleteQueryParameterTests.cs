using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class DeleteQueryParameterTests
    {
        [Theory]
        [InlineData("customParameter")]
        public void CreatesCorrectPolicy(string parameterName)
        {
            var basePolicy = new DeleteQueryParameter(parameterName);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                $@"<set-query-parameter name=""{parameterName}"" exists-action=""delete"" />");
        }
    }
}