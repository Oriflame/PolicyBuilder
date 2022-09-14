using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class RateLimitByKeyPolicyTests
    {
        [Theory]
        [InlineData(100, 200, "Key")]
        public void CreatesCorrectPolicyWithValues(int calls, int renewalPeriod, string counterKey)
        {
            var basePolicy = new RateLimitByKey(calls, renewalPeriod, counterKey);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<rate-limit-by-key calls=\"{calls}\" renewal-period=\"{renewalPeriod}\" counter-key=\"{counterKey}\" />");
        }

        [Theory]
        [InlineData("@(100)", "@(200)", "Key")]
        public void CreatesCorrectPolicyWithExpressions(string calls, string renewalPeriod, string counterKey)
        {
            var basePolicy = new RateLimitByKey(calls, renewalPeriod, counterKey);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<rate-limit-by-key calls=\"{calls}\" renewal-period=\"{renewalPeriod}\" counter-key=\"{counterKey}\" />");
        }
    }
}