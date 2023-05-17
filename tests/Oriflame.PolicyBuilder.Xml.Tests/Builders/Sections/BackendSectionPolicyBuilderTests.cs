using System;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Oriflame.PolicyBuilder.Xml.Mappers;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class BackendSectionPolicyBuilderTests
    {
        [Theory]
        [InlineData(5, true, false, false, true)]
        [InlineData(2, false, false, false, false)]
        [InlineData(1, true, true, true, true)]
        public void CreatesForwardRequestPolicyWithAttributes(int timeout, bool bufferResponse, bool followRedirects, bool failOnErrorStatusCode, bool bufferRequestBody)
        {
            var policyBuilder = new BackendSectionPolicyBuilder(new SectionPolicy("backend"))
                .ForwardRequest(
                    x => x
                        .BufferResponse(bufferResponse)
                        .FollowRedirects(followRedirects)
                        .FailOnErrorStatusCode(failOnErrorStatusCode)
                        .BufferRequestBody(bufferRequestBody)
                        .Timeout(TimeSpan.FromSeconds(timeout))
                        .Create()
                );
            var policy = (SectionPolicy)policyBuilder.Create();
            var xml = policy.GetXml().ToString();

            xml.Should().Be(
                $@"<backend>
  <forward-request buffer-response=""{BoolMapper.Map(bufferResponse)}"" follow-redirects=""{BoolMapper.Map(followRedirects)}"" fail-on-error-status-code=""{BoolMapper.Map(failOnErrorStatusCode)}"" buffer-request-body=""{BoolMapper.Map(bufferRequestBody)}"" timeout=""{timeout}"" />
</backend>");
        }
        
        [Theory]
        [InlineData(5, "true", "false", "false", "true")]
        [InlineData(2, "false", "false", "false", "false")]
        [InlineData(1, "true", "true", "true", "true")]
        public void CreatesForwardRequestPolicyWithStringAttributes(int timeout, string bufferResponse, string followRedirects, string failOnErrorStatusCode, string bufferRequestBody)
        {
            var policyBuilder = new BackendSectionPolicyBuilder(new SectionPolicy("backend"))
                .ForwardRequest(
                    x => x
                        .BufferResponse(bufferResponse)
                        .FollowRedirects(followRedirects)
                        .FailOnErrorStatusCode(failOnErrorStatusCode)
                        .BufferRequestBody(bufferRequestBody)
                        .Timeout(TimeSpan.FromSeconds(timeout))
                        .Create()
                );
            var policy = (SectionPolicy)policyBuilder.Create();
            var xml = policy.GetXml().ToString();

            xml.Should().Be(
                $@"<backend>
  <forward-request buffer-response=""{bufferResponse}"" follow-redirects=""{followRedirects}"" fail-on-error-status-code=""{failOnErrorStatusCode}"" buffer-request-body=""{bufferRequestBody}"" timeout=""{timeout}"" />
</backend>");
        }
        
        [Fact]
        public void CreatesForwardRequestPolicyFromTimespanTimeout()
        {
            const int timeout = 5;
            
            var policyBuilder = new BackendSectionPolicyBuilder(new SectionPolicy("backend"))
                .ForwardRequest(TimeSpan.FromSeconds(timeout));
            var policy = (SectionPolicy)policyBuilder.Create();
            var xml = policy.GetXml().ToString();

            xml.Should().Be(
                $@"<backend>
  <forward-request timeout=""{timeout}"" />
</backend>");
        }
        
        [Fact]
        public void CreatesForwardRequestPolicyFromStringTimeout()
        {
            const int timeout = 5;
            
            var policyBuilder = new BackendSectionPolicyBuilder(new SectionPolicy("backend"))
                .ForwardRequest(timeout.ToString());
            var policy = (SectionPolicy)policyBuilder.Create();
            var xml = policy.GetXml().ToString();

            xml.Should().Be(
                $@"<backend>
  <forward-request timeout=""{timeout}"" />
</backend>");
        }
    }
}