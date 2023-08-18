using System;
using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Expressions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Sections
{
    public class RetryTests
    {
        [Theory]
        [InlineData("0 == 1", 4, 5, true)]
        public void CreatesCorrectPolicy(string condition, int count, int intervalSeconds, bool firstFastRetry)
        {
            var basePolicy = new RetryPolicy(new SingleStatementExpression(condition), count, TimeSpan.FromSeconds(intervalSeconds), firstFastRetry);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be($@"<retry condition=""@({condition})"" count=""{count}"" interval=""{intervalSeconds}"" first-fast-retry=""{ (firstFastRetry ? "true" : "false") }"" />");
        }
    }
}