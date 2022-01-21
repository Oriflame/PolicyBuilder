using System.Collections;
using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Xml.Tests.Builders.Sections.Data
{
    public class TraceTestData
    {
        public string Source;
        public Severity Severity;
        public string Message;
        public TraceMetadataTestData[] Metadata;
    }

    public class TraceMetadataTestData
    {
        public string Name;
        public string Value;
    }

    public class TraceTestDataGenerator
    {

        public class CreatesCorrectFullPolicy : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new TraceTestData
                    {
                        Source = "trace-source",
                        Severity = Severity.Error,
                        Message = "message",
                        Metadata = new TraceMetadataTestData[]
                            {
                                new TraceMetadataTestData
                                {
                                    Name = "foo-name",
                                    Value = "foo-value"
                                },
                                new TraceMetadataTestData
                                {
                                    Name = "bar-name",
                                    Value = "bar-value"
                                }
                            }
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
