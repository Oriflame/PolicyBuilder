using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class RewriteUriPolicyTests
    {
        [Theory]
        [InlineData("/newUriTemplate/{parameter}")]
        public void CreatesCorrectPolicy(string uriTemplate)
        {
            var basePolicy = new RewriteUriPolicy(uriTemplate);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<rewrite-uri template=\"{uriTemplate}\" />");
        }
    }
}