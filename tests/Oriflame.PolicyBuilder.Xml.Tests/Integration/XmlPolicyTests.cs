using FluentAssertions;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Integration
{
    public class XmlPolicyTests
    {
        [Fact]
        public void BuildersFromFactoryGeneratesBasePolicyCorrectly()
        {
            var buildersFactory = new XmlPolicyBuildersFactory();

            var policy = buildersFactory.CreateOperationPolicy();
            buildersFactory.CreateInboundBuilder(policy).Base().Create();
            buildersFactory.CreateBackendBuilder(policy).Base().Create();
            buildersFactory.CreateOutboundBuilder(policy).Base().Create();
            buildersFactory.CreateOnErrorBuilder(policy).Base().Create();
            policy.GetXml().ToString().Should().Be(BasePolicy());
        }

        [Fact]
        public void PolicyBuilderGeneratesBasePolicyCorrectly()
        {
            var buildersFactory = new XmlPolicyBuildersFactory();

            var policy = buildersFactory.CreateOperationPolicy();

            var policyBuilder = new Policies.Builders.PolicyBuilder(
                buildersFactory.CreateInboundBuilder(policy),
                buildersFactory.CreateBackendBuilder(policy),
                buildersFactory.CreateOutboundBuilder(policy),
                buildersFactory.CreateOnErrorBuilder(policy),
                policy);

            policyBuilder
                        .Inbound(a => a.Base().Create())
                        .Backend(a => a.Base().Create())
                        .Outbound(a => a.Base().Create())
                        .OnError(a => a.Base().Create());

            policy.GetXml().ToString().Should().Be(BasePolicy());
        }

        private static string BasePolicy()
        {
            return @"<policies>
  <inbound>
    <base />
  </inbound>
  <backend>
    <base />
  </backend>
  <outbound>
    <base />
  </outbound>
  <on-error>
    <base />
  </on-error>
</policies>";
        }
    }
}
