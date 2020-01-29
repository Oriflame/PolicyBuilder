using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class CommentPolicyTests
    {
        [Theory]
        [InlineData("Testing comment")]
        public void CreatesCorrectPolicy(string comment)
        {
            var basePolicy = new CommentPolicy(comment);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<!-- {comment} -->");
        }
    }
}