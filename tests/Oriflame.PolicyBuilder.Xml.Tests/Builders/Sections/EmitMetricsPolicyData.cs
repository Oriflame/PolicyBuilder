using System.Collections;
using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections
{
    public class EmitMetricsPolicyTestData
    {
        public string Name;
        public string Value;
        public string Namespace;
        public EmitMetricsPolicyDimensionData[] DimensionsDatas;
    }

    public class EmitMetricsPolicyDimensionData
    {
        public string Name;
        public string Value;
    }

    public class EmitMetricsPolicyDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new EmitMetricsPolicyTestData
                {
                    Name = "policy-name",
                    Value = "policy-value",
                    Namespace = "policy-namespace",
                    DimensionsDatas = new EmitMetricsPolicyDimensionData[]
                        {
                            new EmitMetricsPolicyDimensionData
                            {
                                Name = "foo",
                                Value = "foo-value"
                            },
                            new EmitMetricsPolicyDimensionData
                            {
                                Name = "bar",
                                Value = "bar-value"
                            }
                        }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
