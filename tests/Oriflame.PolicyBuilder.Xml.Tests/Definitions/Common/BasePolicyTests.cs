using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class BasePolicyTests
    {
        [Fact]
        public void CreatesCorrectPolicy()
        {
            var basePolicy = new BasePolicy();
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be("<base />");
        }
    }
}
