using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class CacheLookupSectionTests
    {
        private const string headerTenant = "x-tenant-context";
        private const string headerApplication = "x-application-context";
        private const string queryParam = "someQueryParam";

        [Fact]
        public void CreatesCorrectPolicy()
        {
            var attributes = new CacheLookupAttributesBuilder().Create();
            var basePolicy = (SectionPolicy)new CacheLookupSectionBuilder(attributes).Create();
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be("<cache-lookup />");
        }

        [Fact]
        public void CreatesCorrectPolicyWithAttributes()
        {
            var attributes =
                new CacheLookupAttributesBuilder()
                    .VaryByDeveloper(true)
                    .VaryByDeveloperGroups(false)
                    .DownstreamCachingType(DownstreamCachingType.Public)
                    .AllowPrivateResponseCaching(true)
                    .Create();

            var basePolicy = (SectionPolicy)new CacheLookupSectionBuilder(attributes).Create();
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
                $"<cache-lookup vary-by-developer=\"true\" vary-by-developer-groups=\"false\" downstream-caching-type=\"public\" allow-private-response-caching=\"true\" />");
        }

        [Fact]
        public void CreatesCorrectPolicyWithAttributesAndParameters()
        {
            var attributes =
                new CacheLookupAttributesBuilder()
                    .VaryByDeveloper(true)
                    .VaryByDeveloperGroups(false)
                    .DownstreamCachingType(DownstreamCachingType.Public)
                    .AllowPrivateResponseCaching(true)
                    .CachingType(CachingType.PreferExternal)
                    .Create();

            var basePolicy = (SectionPolicy)
                new CacheLookupSectionBuilder(attributes)
                    .VaryByHeader(headerTenant)
                    .VaryByHeader(headerApplication)
                    .VaryByQueryParameter(queryParam)
                    .Create();
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
$@"<cache-lookup vary-by-developer=""true"" vary-by-developer-groups=""false"" downstream-caching-type=""public"" allow-private-response-caching=""true"" caching-type=""prefer-external"">
  <vary-by-header>{headerTenant}</vary-by-header>
  <vary-by-header>{headerApplication}</vary-by-header>
  <vary-by-query-parameter>{queryParam}</vary-by-query-parameter>
</cache-lookup>");
        }

        [Fact]
        public void CreatesCorrectPolicyWhenNoBuilderSpecified()
        {
            var policyBuilder = new InboundSectionPolicyBuilder(new SectionPolicy("inbound"))
                .CacheLookup(
                    x => x
                    .VaryByDeveloper(true)
                    .Create()
                );
            var policy = (SectionPolicy)policyBuilder.Create();
            var xml = policy.GetXml().ToString();

            xml.Should().Be(
$@"<inbound>
  <cache-lookup vary-by-developer=""true"" />
</inbound>");
        }

        [Fact]
        public void CreatesCorrectPolicyWhenBuilderSpecified()
        {
            var policyBuilder = new InboundSectionPolicyBuilder(new SectionPolicy("inbound"))
                .CacheLookup(
                    attrs => attrs
                        .VaryByDeveloper(true)
                        .Create(),
                    builder => builder
                        .VaryByHeader(headerTenant)
                        .Create()
                );
            var policy = (SectionPolicy)policyBuilder.Create();
            var xml = policy.GetXml().ToString();

            xml.Should().Be(
$@"<inbound>
  <cache-lookup vary-by-developer=""true"">
    <vary-by-header>{headerTenant}</vary-by-header>
  </cache-lookup>
</inbound>");
        }
    }
}