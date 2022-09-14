using System;
using FluentAssertions;
using Oriflame.PolicyBuilder.Policies.Extensions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class RetrySectionBuilderTests
    {
        [Theory]
        [InlineData("@(0 == 1)", 5, "10", true)]
        public void CreatesCorrectPolicyOverload1(string condition, int count, string interval, bool? firstFastRetry)
        {
            var policy = new RetryPolicy(condition, count, interval, firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""{ condition }"" count=""{count}"" interval=""{interval}"" first-fast-retry=""{firstFastRetry}"" />".ToLower());
        }

        [Theory]
        [InlineData("@(0 == 1)", "5", "10", true)]
        public void CreatesCorrectPolicyOverload2(string condition, string count, string interval, bool? firstFastRetry)
        {
            var policy = new RetryPolicy(condition, count, interval, firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""{ condition }"" count=""{count}"" interval=""{interval}"" first-fast-retry=""{firstFastRetry}"" />".ToLower());
        }

        [Theory]
        [InlineData("@(0 == 1)", 5, true)]
        public void CreatesCorrectPolicyOverload3(string condition, int count, bool? firstFastRetry)
        {
            var interval = TimeSpan.FromSeconds(10);

            var policy = new RetryPolicy(condition, count, interval, firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""{ condition }"" count=""{count}"" interval=""{interval.GetSeconds()}"" first-fast-retry=""{firstFastRetry}"" />".ToLower());
        }

        [Theory]
        [InlineData("@(0 == 1)", "5", true)]
        public void CreatesCorrectPolicyOverload4(string condition, string count, bool? firstFastRetry)
        {
            var interval = TimeSpan.FromSeconds(10);

            var policy = new RetryPolicy(condition, count, interval, firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""{ condition }"" count=""{count}"" interval=""{interval.GetSeconds()}"" first-fast-retry=""{firstFastRetry}"" />".ToLower());
        }

        [Theory]
        [InlineData("@(0 == 1)", "5", "10", "@(true)")]
        public void CreatesCorrectPolicyOverload5(string condition, string count, string interval, string firstFastRetry)
        {
            var policy = new RetryPolicy(condition, count, interval, firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""{ condition }"" count=""{count}"" interval=""{interval}"" first-fast-retry=""{firstFastRetry}"" />".ToLower());
        }

        [Theory]
        [InlineData("@(0 == 1)", "5", null)]
        public void CreatesCorrectPolicyOverload6(string condition, string count, bool? firstFastRetry)
        {
            var interval = TimeSpan.FromSeconds(10);

            var policy = new RetryPolicy(condition, count, interval, firstFastRetry);

            var xml = policy.GetXml().ToString();
            xml.Should().Be(
                $@"<retry condition=""{ condition }"" count=""{count}"" interval=""{interval.GetSeconds()}"" />".ToLower());
        }
    }
}
