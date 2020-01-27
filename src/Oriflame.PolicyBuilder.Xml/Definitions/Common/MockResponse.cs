using System.Net;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class MockResponse : PolicyXmlBase
    {
        public MockResponse(HttpStatusCode? statusCode, string contentType) : base("mock-response")
        {
            if (statusCode != null)
            {
                Attributes.Add("status-code", ((int)statusCode).ToString());
            }

            if (contentType != null)
            {
                Attributes.Add("content-type", contentType);
            }
        }
    }
}