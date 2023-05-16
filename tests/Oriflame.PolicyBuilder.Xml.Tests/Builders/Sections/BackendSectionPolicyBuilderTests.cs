﻿using System;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class BackendSectionPolicyBuilderTests
    {
        [Fact]
        public void CreatesForwardRequestPolicyWithAttributes()
        {
            const int timeout = 5;
            
            var policyBuilder = new BackendSectionPolicyBuilder(new SectionPolicy("backend"))
                .ForwardRequest(
                    x => x
                        .BufferResponse(true)
                        .FollowRedirects(false)
                        .FailOnErrorStatusCode(true)
                        .BufferRequestBody(true)
                        .Timeout(TimeSpan.FromSeconds(timeout))
                        .Create()
                );
            var policy = (SectionPolicy)policyBuilder.Create();
            var xml = policy.GetXml().ToString();

            xml.Should().Be(
                $@"<backend>
  <forward-request buffer-response=""true"" follow-redirects=""false"" fail-on-error-status-code=""true"" buffer-request-body=""true"" timeout=""{timeout}"" />
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