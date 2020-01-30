using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Oriflame.PolicyBuilder.Xml.Mappers;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class ReturnResponseSectionBuilderTests
    {
        [Theory]
        [InlineData("OK", "200", "Success")]
        public void CreatesCorrectPolicy(string body, string statusCode, string reason)
        {
            var sectionPolicy = 
                new ReturnResponseSectionBuilder()
                    .SetBody(body)
                    .SetStatus(statusCode, reason)
                    .Create();

            var xml = ((SectionPolicy)sectionPolicy).GetXml().ToString();
            xml.Should().Be(
$@"<return-response>
  <set-body>{body}</set-body>
  <set-status code=""{statusCode}"" reason=""{reason}"" />
</return-response>");
        }
    }
}