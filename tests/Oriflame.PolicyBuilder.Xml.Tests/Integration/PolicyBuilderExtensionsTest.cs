using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Builders.Extensions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Integration
{
    public class PolicyBuilderExtensionsTest
    {
        [Fact]
        public void RewriteUriCreatesCorrectPolicy()
        {
            // Assign
            var uri = "/api/ping";
            var policy = GetPolicyBuilder();

            // Act
            policy.PolicyBuilder.RewriteUri(uri);

            // Assert
            policy.Policy.GetXml().ToString().Should().Be(GetRewriteUrlPolicy(uri));
        }

        [Fact]
        public void RewriteUriWithBackendSectionOverrideCreatesCorrectPolicy()
        {
            // Assign
            var uri = "/api/ping";
            var policy = GetPolicyBuilder();

            // Act
            policy.PolicyBuilder.RewriteUri(uri, b => b.Backend());

            // Assert
            policy.Policy.GetXml().ToString().Should().Be(GetRewriteUrlPolicy(uri));
        }

        [Fact]
        public void SetBackendServiceCreatesCorrectPolicy()
        {
            // Assign
            var domain = "http://test.ori";
            var policy = GetPolicyBuilder();

            // Act
            policy.PolicyBuilder.SetBackendService(domain);

            // Assert
            policy.Policy.GetXml().ToString().Should().Be(GetSetBackendPolicy(domain));
        }

        [Fact]
        public void SetBackendServiceWithBackendSectionOverrideCreatesCorrectPolicy()
        {
            // Assign
            var domain = "http://test.ori";
            var policy = GetPolicyBuilder();

            // Act
            policy.PolicyBuilder.SetBackendService(domain, b => b.Backend());

            // Assert
            policy.Policy.GetXml().ToString().Should().Be(GetSetBackendPolicy(domain));
        }

        [Fact]
        public void SetBackendAndRewriteUriCreatesCorrectPolicy()
        {
            // Assign
            var domain = "http://test.ori";
            var uri = "/api/ping";
            var policy = GetPolicyBuilder();

            // Act
            policy.PolicyBuilder.SetBackendAndRewriteUri(domain, uri);

            // Assert
            policy.Policy.GetXml().ToString().Should().Be(GetSetBackendAndRewriteUriPolicy(domain, uri));
        }

        [Fact]
        public void SetBackendAndRewriteUriWithBackendSectionOverrideCreatesCorrectPolicy()
        {
            // Assign
            var domain = "http://test.ori";
            var uri = "/api/ping";
            var policy = GetPolicyBuilder();

            // Act
            policy.PolicyBuilder.SetBackendAndRewriteUri(domain, uri, b => b.Backend());

            // Assert
            policy.Policy.GetXml().ToString().Should().Be(GetSetBackendAndRewriteUriPolicy(domain, uri));
        }

        private static string GetRewriteUrlPolicy(string uri)
        {
            return @$"<policies>
  <inbound>
    <base />
    <rewrite-uri template=""{uri}"" />
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
        private static string GetSetBackendPolicy(string domain)
        {
            return @$"<policies>
  <inbound>
    <base />
    <set-backend-service base-url=""{domain}"" />
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

        private static string GetSetBackendAndRewriteUriPolicy(string domain, string uri)
        {
            return @$"<policies>
  <inbound>
    <base />
    <set-backend-service base-url=""{domain}"" />
    <rewrite-uri template=""{uri}"" />
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

        private static (IPolicyBuilder PolicyBuilder, XmlOperationPolicy Policy) GetPolicyBuilder()
        {
            var buildersFactory = new XmlPolicyBuildersFactory();

            var policy = buildersFactory.CreateOperationPolicy();
            var policyBuilder = new Policies.Builders.PolicyBuilder(
                buildersFactory.CreateInboundBuilder(policy),
                buildersFactory.CreateBackendBuilder(policy),
                buildersFactory.CreateOutboundBuilder(policy),
                buildersFactory.CreateOnErrorBuilder(policy),
                policy);

            return (policyBuilder, policy);
        }
    }
}
