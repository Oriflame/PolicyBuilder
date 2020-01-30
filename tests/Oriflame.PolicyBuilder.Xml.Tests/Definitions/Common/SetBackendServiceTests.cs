using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class SetBackendServiceTests
    {
        [Theory]
        [InlineData("https://newBackendService.com")]
        public void CreatesCorrectPolicy(string url)
        {
            var basePolicy = new SetBackendService(url);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<set-backend-service base-url=\"{url}\" />");
        }
    }
}