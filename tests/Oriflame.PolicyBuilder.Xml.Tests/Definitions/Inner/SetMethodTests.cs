using System.Net.Http;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Inner
{
    public class SetMethodTests
    {
        [Theory]
        [InlineData("PUT")]
        public void CreatesCorrectPolicy(string method)
        {
            var basePolicy = new SetMethod(new HttpMethod(method));
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<set-method>{method}</set-method>");
        }
    }
}