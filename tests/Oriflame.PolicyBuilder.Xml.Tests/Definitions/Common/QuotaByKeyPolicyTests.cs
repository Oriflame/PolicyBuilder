using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class QuotaByKeyPolicyTests
    {
        [Theory]
        [InlineData(100, 200, 300, "Key")]
        public void CreatesCorrectPolicyWithValues(int calls, int bandwidth, int renewalPeriod, string counterKey)
        {
            var basePolicy = new QuotaByKey(calls, bandwidth, renewalPeriod, counterKey);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<quota-by-key calls=\"{calls}\" bandwidth=\"{bandwidth}\" renewal-period=\"{renewalPeriod}\" counter-key=\"{counterKey}\" />");
        }

        [Theory]
        [InlineData("@(100)", "@(200)", "@(300)", "Key")]
        public void CreatesCorrectPolicyWithExpressions(string calls, string bandwidth, string renewalPeriod, string counterKey)
        {
            var basePolicy = new QuotaByKey(calls, bandwidth, renewalPeriod, counterKey);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($"<quota-by-key calls=\"{calls}\" bandwidth=\"{bandwidth}\" renewal-period=\"{renewalPeriod}\" counter-key=\"{counterKey}\" />");
        }
    }
}