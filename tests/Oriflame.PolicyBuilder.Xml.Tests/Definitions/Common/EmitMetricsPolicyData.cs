using System.Collections;
using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Xml.Tests.Definitions.Common
{
    public class EmitMetricsPolicyTestData
    {
        public string Name;
        public string Value;
        public string Namespace;
        public EmitMetricsPolicyDimentionData[] DimentionsDatas;
    }

    public class EmitMetricsPolicyDimentionData
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
                    DimentionsDatas = new EmitMetricsPolicyDimentionData[]
                        {
                            new EmitMetricsPolicyDimentionData
                            {
                                Name = "foo",
                                Value = "foo-value"
                            },
                            new EmitMetricsPolicyDimentionData{
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
