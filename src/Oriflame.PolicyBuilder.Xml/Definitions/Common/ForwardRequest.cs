using System;
using Oriflame.PolicyBuilder.Xml.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class ForwardRequest : PolicyXmlBase
    {
        public ForwardRequest(TimeSpan? timeout) : base("forward-request")
        {
            if (timeout != null)
            {
                Attributes.Add("timeout", timeout.Value.GetSeconds());
            }
        }
    }
}