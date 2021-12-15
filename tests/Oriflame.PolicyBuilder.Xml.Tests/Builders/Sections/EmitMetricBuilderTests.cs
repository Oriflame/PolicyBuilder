using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class EmitMetricBuilderTests
    {
        [Theory]
        [InlineData("foo", "foo-value", "foo-namespace")]
        public void CreatesCorrectPolicy(string name, string value, string @namespace)
        {
            var attributes = new Dictionary<string, string>()
            {
                { "name", name },
                { "value", value },
                { "namespace", @namespace }
            };

            var basePolicy = new EmitMetricPolicyBuilder(attributes).Create() as SectionPolicy;
            var xml = basePolicy?.GetXml().ToString();
            xml.Should().Be(@$"<emit-metric name=""{name}"" value=""{value}"" namespace=""{@namespace}"" />");
        }

        [Theory]
        [ClassData(typeof(EmitMetricsPolicyDataGenerator))]
        public void CreatesCorrectComplexPolicy(EmitMetricsPolicyTestData data)
        {
            var attributes = new Dictionary<string, string>()
            {
                { "name", data.Name },
                { "value", data.Value },
                { "namespace", data.Namespace }
            };
            var builder = new EmitMetricPolicyBuilder(attributes);
            foreach (var d in data.DimensionsDatas)
            {
                builder.Dimension(d.Name, d.Value);
            }
            var basePolicy = builder.Create() as SectionPolicy;

            var xml = basePolicy.GetXml().ToString();

            xml.Should().Be(
$@"<emit-metric name=""{data.Name}"" value=""{data.Value}"" namespace=""{data.Namespace}"">
" + (data.DimensionsDatas).Select(x =>
    $@"  <dimension name=""{x.Name}"" value=""{x.Value}"" />").Aggregate("", (prev, curr) => $"{prev}{curr}\n") +
"</emit-metric>");
        }
    }
}