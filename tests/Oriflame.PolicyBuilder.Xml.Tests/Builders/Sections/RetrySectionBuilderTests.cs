using System;
using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Expressions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class RetrySectionBuilderTests
    {
        [Theory]
        [InlineData("0 == 1", 5, 10, true)]
        public void CreatesCorrectPolicyOverload1(string condition, int count, int interval, bool? firstFastRetry)
        {
            var policy = new RetryPolicy(new SingleStatementExpression(condition), count, TimeSpan.FromSeconds(interval), firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""@({condition})"" count=""{count}"" interval=""{interval}"" first-fast-retry=""{firstFastRetry}"" />".ToLower());
        }

        [Theory]
        [InlineData("0 == 1", "5", 10, true)]
        public void CreatesCorrectPolicyOverload2(string condition, string count, int interval, bool? firstFastRetry)
        {
            var policy = new RetryPolicy(new SingleStatementExpression(condition), new SingleStatementExpression(count), TimeSpan.FromSeconds(interval), firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""@({condition})"" count=""@({count})"" interval=""{interval}"" first-fast-retry=""{firstFastRetry}"" />".ToLower());
        }

        [Theory]
        [InlineData("0 == 1", 5, "10", true)]
        public void CreatesCorrectPolicyOverload3(string condition, int count, string interval, bool? firstFastRetry)
        {
            var policy = new RetryPolicy(new SingleStatementExpression(condition), count, new SingleStatementExpression(interval), firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""@({condition})"" count=""{count}"" interval=""@({interval})"" first-fast-retry=""{firstFastRetry}"" />".ToLower());
        }

        [Theory]
        [InlineData("0 == 1", 5, 10, "true")]
        public void CreatesCorrectPolicyOverload4(string condition, int count, int interval, string firstFastRetry)
        {
            var policy = new RetryPolicy(new SingleStatementExpression(condition), count, TimeSpan.FromSeconds(interval), new SingleStatementExpression(firstFastRetry));

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""@({condition})"" count=""{count}"" interval=""{interval}"" first-fast-retry=""@({firstFastRetry})"" />".ToLower());
        }

        [Theory]
        [InlineData("0 == 1", "5", "10", true)]
        public void CreatesCorrectPolicyOverload5(string condition, string count, string interval, bool? firstFastRetry)
        {
            var policy = new RetryPolicy(new SingleStatementExpression(condition), new SingleStatementExpression(count), new SingleStatementExpression(interval), firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""@({condition})"" count=""@({count})"" interval=""@({interval})"" first-fast-retry=""{firstFastRetry}"" />".ToLower());
        }

        [Theory]
        [InlineData("0 == 1", "5", "10", "true")]
        public void CreatesCorrectPolicyOverload6(string condition, string count, string interval, string firstFastRetry)
        {
            var policy = new RetryPolicy(new SingleStatementExpression(condition), new SingleStatementExpression(count), new SingleStatementExpression(interval), new SingleStatementExpression(firstFastRetry));

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""@({condition})"" count=""@({count})"" interval=""@({interval})"" first-fast-retry=""@({firstFastRetry})"" />".ToLower());
        }
    }
}
