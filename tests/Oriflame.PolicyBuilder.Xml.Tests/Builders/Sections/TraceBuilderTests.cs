using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections.Data;
using Xunit;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class TraceBuilderTests
    {
        [Theory]
        [ClassData(typeof(TraceTestDataGenerator.CreatesCorrectFullPolicy))]
        public void CreatesCorrectFullPolicy(TraceTestData data)
        {
            var attributes = new Dictionary<string, string>()
            {
                { "source", data.Source },
                { "severity", data.Severity.ToString().ToLower() }                
            };
            var builder = new TracePolicyBuilder(attributes);
            builder.Message(data.Message);
            foreach (var m in data.Metadata)
            {
                builder.Metadata(m.Name, m.Value);
            }
            var basePolicy = builder.Create() as SectionPolicy;

            var xml = basePolicy.GetXml().ToString();
            xml.Should().Be(
$@"<trace source=""{data.Source}"" severity=""{data.Severity.ToString().ToLower()}"">
  <message>{data.Message}</message>
" + data.Metadata.Select(x =>
$@"  <metadata name=""{x.Name}"" value=""{x.Value}"" />").Aggregate("", (prev, curr) => $"{prev}{curr}{System.Environment.NewLine}") +
"</trace>");
        }
    }
}