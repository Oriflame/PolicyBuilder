using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class DeleteHeaderTests
    {
        [Theory]
        [InlineData("customParameter")]
        public void CreatesCorrectPolicy(string parameterName)
        {
            var basePolicy = new DeleteHeader(parameterName);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                $@"<set-header name=""{parameterName}"" exists-action=""delete"" />");
        }
    }
}