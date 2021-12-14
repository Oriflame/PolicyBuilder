using System.Linq;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class EmitMetricsTests
    {
        [Theory]
        [InlineData("foo", "foo-value", "foo-namespace")]
        public void CreatesCorrectPolicy(string name, string value, string @namespace)
        {
            var basePolicy = new EmitMetricPolicy(name, value, @namespace);
            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(@$"<emit-metric name=""{name}"" value=""{value}"" namespace=""{@namespace}"" />");
        }

//        [Theory]
//        [ClassData(typeof(EmitMetricsPolicyDataGenerator))]
//        public void CreatesCorrectComplexPolicy(EmitMetricsPolicyTestData data)
//        {
//            var dimentions = (data.DimentionsDatas).Select(x => new Dimention(x.Name, x.Value));
//            var basePolicy = new EmitMetricPolicy(data.Name, data.Value, data.Namespace, dimentions);

//            var xml = basePolicy.GetXml().ToString();

//            xml.Should().Be(
//$@"<emit-metric name=""{data.Name}"" value=""{data.Value}"" namespace=""{data.Namespace}"">
//" + (data.DimentionsDatas).Select(x =>
//    $@"  <dimention name=""{x.Name}"" value=""{x.Value}"" />").Aggregate("", (prev, curr) => $"{prev}{curr}\n") +
//"</emit-metric>");
//        }

//        public void CreatesCorrectComplexPolicy(EmitMetricsPolicyTestData data)
//        {
//            var dimentions = (data.DimentionsDatas).Select(x => new Dimention(x.Name, x.Value));
//            var basePolicy = new EmitMetricPolicy(data.Name, data.Value, data.Namespace, dimentions);

//            var xml = basePolicy.GetXml().ToString();

//            xml.Should().Be(
//$@"<emit-metric name=""{data.Name}"" value=""{data.Value}"" namespace=""{data.Namespace}"">
//" + (data.DimentionsDatas).Select(x =>
//    $@"  <dimention name=""{x.Name}"" value=""{x.Value}"" />").Aggregate("", (prev, curr) => $"{prev}{curr}\n") +
//"</emit-metric>");
//        }
    }
}